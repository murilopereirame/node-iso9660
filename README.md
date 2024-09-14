# Node.js ISO File Reader

This Node.js library uses C# WebAssembly to read files inside ISO files. The C# part leverages DiscUtils to manipulate the ISO file and Bootsharp to generate the WebAssembly and JavaScript glue code.

## Features

- Read files inside ISO files
- Manipulate ISO files using DiscUtils
- WebAssembly integration with Bootsharp

## Prerequisites

- Node.js
- npm (Node Package Manager)
- .NET SDK 8.0 (Only if you want to modify it)

## Installation

To install the library, run:

```bash
npm install node-iso9660
```

## Usage

Here's a basic example of how to use the library:

```javascript
import { IsoFs } from "node-iso9660"

const fs = await IsoFs.init("path/to/iso/file.iso")
const bytes = fs.readFile("file/inside/iso")

console.log(bytes)
```

## Building the Project

To build the project, run:

```bash
npm run build
```

## Compiling WebAssembly

To compile the WebAssembly, run:

```bash
npm run compile
```

## License

This project is licensed under the GPLv3 License. See the LICENSE file for details.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## Acknowledgements

- [DiscUtils](https://github.com/DiscUtils/DiscUtils)
- [Bootsharp](https://github.com/elringus/bootsharp)