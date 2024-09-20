import bootsharp, {IsoReader} from "bootsharp";
import Reader = IsoReader.Reader;
import {IsoStream} from "./IsoStream";

export class IsoFs {
    private stream: IsoStream

    static init = async (path: string) => {
        if (bootsharp.getStatus() === bootsharp.BootStatus.Standby) {
            await bootsharp.boot();
        }

        return new IsoFs(path)
    }

    private constructor(private readonly path: string) {
        this.stream = new IsoStream(this.path);
    }

    readFile(path: string) {
        const sharpPath = path.replace("/", "\\");
        return Reader.readFileFromIso(sharpPath);
    }

    listFiles(path: string) {
        const sharpPath = path.replace("/", "\\");
        return Reader.listFilesFromIso(sharpPath);
    }

    listDirectories(path: string) {
        const sharpPath = path.replace("/", "\\");
        return Reader.listDirectoriesFromIso(sharpPath);
    }

    listTreeDirectories(path: string) {
        const sharpPath = path.replace("/", "\\");
        return Reader.listFilesTreeFromIso(sharpPath);
    }

    dispose() {
        this.stream.dispose()
    }
}