import fs from "fs"
import {IsoReader} from "bootsharp";
import Reader = IsoReader.Reader;

export class IsoStream {
    private position: bigint = BigInt(0)
    private length: bigint = BigInt(0);
    private fd: number;

    constructor(filePath: string) {
        this.length = BigInt(fs.statSync(filePath).size);
        this.fd = fs.openSync(filePath, "r");
        this.setupBridge()
    }

    private read = (offset: number, count: number) => {
        const buffer = Buffer.alloc(count)
        fs.readSync(this.fd, buffer, offset, count, this.position)
        return buffer
    }

    private setPosition = (position: bigint) => {
        this.position = position
    }

    private streamlLength = (): bigint => {
        return this.length
    }

    private setupBridge = () => {
        Reader.streamLength = this.streamlLength
        Reader.read = this.read
        Reader.setPosition = this.setPosition
    }

    dispose = () => {
        fs.closeSync(this.fd)
        this.fd = -1
        this.length = BigInt(0)
        this.position = BigInt(0)
    }
}