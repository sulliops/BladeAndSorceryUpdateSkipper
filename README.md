# Blade and Sorcery Update Skipper

*Created by Owen Sullivan, [sulliops.co](https://sulliops.co)*

----

#### What is it?

Blade and Sorcery Update Skipper is a program written in C# designed to help prevent Blade and Sorcery from updating automatically through Steam. It modifies the game's appmanifest file, which Steam uses to determine when updates are needed, and tricks Steam into thinking no updates are available.

This program is heavily inspired by the existing [BeatSaber_UpdateSkipper](https://github.com/kinsi55/BeatSaber_UpdateSkipper) tool, which I've been using for quite some time to prevent my Beat Saber mods from breaking with automatic updates. The same ended up happening to my Blade and Sorcery installation, so I decided to spend Labor Day building an equivalent for those of us that just want to throw lightsabers around from time to time.

----

#### Using the tool:

v1.1.0 uses a standard application installer from [Inno Setup](https://jrsoftware.org/isinfo.php), but the pre-compiled release can also be downloaded and extracted to any valid directory for use. You can build the executable yourself (see below), or download the latest release from the repository's [Releases](https://github.com/sulliops/BladeAndSorceryUpdateSkipper/releases) page.

Then, simply launch Blade and Sorcery Update Skipper whenever Steam shows an update is available. The tool will automatically disable auto-updating for Blade and Sorcery after the first successful run, and will create a folder containing a timestamped backup of the current appmanifest file. You can choose the location for the appmanifest backup, or stick with the default backup location in `C:\Users\[CURRENT_USER]\Documents\`.

![Application screenshot](./Preview.png "Application screenshot")

----

#### Compiling:

v1.1.0 is compiled using Visual Studio 2022's ".NET desktop development" suite of tools. The solution (.sln file) can be opened in Visual Studio 2022, and Blade and Sorcery Update Skipper can be built against the "Release | Any CPU" target.

The tool is compatible with x86 and x64 installations of Windows by default, as Steam itself is a 32-bit application. Only Windows 10 and Windows 11 have been tested, although this should be enough given that most VR platforms only run on these operating system versions.

Support for Linux-based operating systems is not planned at this time.

----

#### Notes:

1. There are no guarantees with this tool, so **use it at your own risk**. I'm a student and this is my first C# application, so there may be all sorts of bugs that I haven't uncovered yet. I am not responsible for broken game installations.

----

#### Known Issues:

1. The application or its installer may trigger false positive reports with built-in or third-party anti-virus programs. This is because neither are signed with a code signing certificate. Hopefully, the open-source nature of this program will ease folks' concerns.
