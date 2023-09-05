# Blade and Sorcery Update Skipper

### Version 1.0.0

*Created by Owen Sullivan, [sulliops.co](https://sulliops.co)*

----

#### What is Blade and Sorcery Update Skipper?

Blade and Sorcery Update Skipper is a program written in C# designed to help prevent Blade and Sorcery from updating automatically through Steam. It modifies the game's appmanifest file, which Steam uses to determine when updates are needed, and tricks Steam into thinking no updates are available.

----

#### Using Blade and Sorcery Update Skipper:

Version 1.0.0 uses a standard application installer from [Inno Setup](https://jrsoftware.org/isinfo.php), but the pre-compiled release can also be downloaded and extracted to any valid directory for use. You can build the executable yourself (see **Compiling Blade and Sorcery Update Skipper** below), or download the latest release from the repository's [Releases](https://github.com/sulliops/BladeAndSorceryUpdateSkipper/releases) page.

Then, simply launch Blade and Sorcery Update Skipper whenever Steam shows an update is available. The tool will automatically disable auto-updating for Blade and Sorcery after the first successful run.

----

#### Compiling Blade and Sorcery Update Skipper

v1.0.0 is compiled using Visual Studio 2022. The solution (.sln file) can be opened in Visual Studio with the default installation of .NET desktop development tools, and Blade and Sorcery Update Skipper can be built against the Release target.

----

#### TO-DO (for future versions):
1. Fix check for manifest ID length to use range from 16 to 19 (inclusive).
2. Automatically backup existing appmanifest file in case program generates errors.
3. Make README better (maybe add a picture or two).
