[![downloads][downloads-shield]][downloads-url] [![Contributors][contributors-shield]][contributors-url] [![Forks][forks-shield]][forks-url] [![Stargazers][stars-shield]][stars-url] [![Issues][issues-shield]][issues-url] [![License][license-shield]][license-url] [![LinkedIn][linkedin-shield]][linkedin-url]

# ![Logo][Logo] UseCaseCanvas
Create use case documentation as Mermaid files and Markdown files for projects.

## Overview
UseCaseCanvas is a .NET library and tooling set that helps you define use cases (actors, scenarios, relationships) and generate:

- Mermaid diagrams (`.mmd`) for visual representation
- Markdown documentation (`.md`) for human-readable specifications

It includes a WinUI demo application and a source-generator project to assist integration in applications and libraries.

## Features
- Generate Mermaid diagrams and Markdown documentation

## Quick Start

### Prerequisites
- Windows10/11 (for WinUI demo and packaging)
- Development Environment with (optional):
    - .NET9 SDK
    - Visual Studio2022/2023 or later with the WinUI/Windows App SDK workloads (recommended)

### Clone the repository

```bash
git clone https://github.com/Tirsvad/TirsvadGUI.Dotnet.WinUi3.UseCaseCanvas.git
cd TirsvadGUI.Dotnet.WinUi3.UseCaseCanvas
```

Build the projects

```bash
# Build all projects (Release recommended)
dotnet build src -c Release

# Run the WinUI demo app (if you want to try the UI)
dotnet run --project "src/TirsvadGUI.UseCaseCanvas.WinUI/TirsvadGUI.UseCaseCanvas.WinUI.csproj" -c Debug
```

Notes
- The solution contains two main projects:
 - `src/TirsvadGUI.WinUi3.UseCaseCanvas.Generators` — source generator and library code (targets .NET Standard2.0)
 - `src/TirsvadGUI.UseCaseCanvas.WinUI` — WinUI demo application (targets .NET9)
- Packaging output and generated artifacts are placed under the repository `BaseOutputPath` during CI/local builds. See `Directory.Build.props` for defaults.

## Usage

The library is intended to be consumed from other .NET projects. Typical integration steps:

1. Add a project reference to the generator/library project or install the NuGet package (if published).
2. Create use case definitions in code or files in your project.
3. Call the library API to generate `.mmd` and `.md` files as part of your build or a custom tool.

Example (conceptual)

```csharp
// Pseudocode - consult the source for real API details
var canvas = new UseCaseCanvas();
canvas.AddActor("User");
canvas.AddUseCase("Login", "User logs in to the system");
canvas.GenerateMermaid("docs/diagrams/login.mmd");
canvas.GenerateMarkdown("docs/usecases/login.md");
```

For concrete usage examples, check the `src` folder and the WinUI demo project.

## Folder Structure (example)

```plaintext
Dotnet.WinUi3.UseCaseCanvas/
├── src/
│ ├── TirsvadGUI.WinUi3.UseCaseCanvas.Generators/ # Library + source generator
│ └── TirsvadGUI.UseCaseCanvas.WinUI/ # WinUI demo app
└── tests/ # Unit tests (if present)
```

## Contributing
Contributions are welcome. Please follow the guidelines in `CONTRIBUTING.md` and open issues or pull requests.

See [CONTRIBUTING.md](CONTRIBUTING.md)

## Reporting Bugs
1. Go to the Issues page: [GitHub Issues][githubIssue-url]
2. Click "New Issue" and provide steps to reproduce, expected behavior, actual behavior, environment, and attachments (logs/screenshots).

## License
Distributed under the AGPL-3.0 License. See [LICENSE.txt](LICENSE.txt) or [license link][license-url].

## Contact
Jens Tirsvad Nielsen - [LinkedIn][linkedin-url]

## Acknowledgments
Thanks to contributors and the open-source community.

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas?style=for-the-badge
[contributors-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas?style=for-the-badge
[forks-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas?style=for-the-badge
[stars-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas?style=for-the-badge
[issues-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/issues
[license-shield]: https://img.shields.io/github/license/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas?style=for-the-badge
[license-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[githubIssue-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/issues/
[logo]: https://raw.githubusercontent.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/main/images/logo/32x32/logo.png

<!-- If there is example code -->
<!--
[example-url]: https://raw.githubusercontent.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/main/src/Example/Example.cs
-->
<!-- If this is a downloadable package from github -->
[downloads-shield]: https://img.shields.io/github/downloads/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/total?style=for-the-badge
[downloads-url]: https://github.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/releases
<!-- If there is screenshots -->
<!--
[screenshot1]: https://raw.githubusercontent.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/main/images/small/Screenshot1.png
[screenshot1-url]: https://raw.githubusercontent.com/TirsvadGUI/Dotnet.WinUi3.UseCaseCanvas/main/images/Screenshot1.png
-->