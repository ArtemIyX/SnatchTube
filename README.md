# Snatch Tube  
> Fast, tiny, cross-platform YouTube downloader for .NET 6+

Download any public YouTube video as an `.mp4` with one command.

---

## 📥 Installation

### Option 1 – Grab a pre-built binary
Head to the [Releases](https://github.com/ArtemIyX/SnatchTube/releases) page and download the executable for Windows.
No runtime required—just unzip and run.

### Option 2 – Build from source
See the “Build & Publish” section below.

## ⚡ Usage

| Command | Result |
|---------|--------|
| `dotnet run` | **Interactive mode** - prompts you for a URL each time. |
| `dotnet run -- <url>` | **Download immediately** - pass the video URL as an argument. |
| `dotnet run -- --help` or `-h` | Show built-in help. |

### Default Output Directory
- **Windows:** `%USERPROFILE%\Downloads\`
- **macOS / Linux:** `~/Downloads/`

---

## 🛠️ Build & Publish

| Target | Command |
|--------|---------|
| **Debug build** | `dotnet build` |
| **Single-file executable (Windows)** | `dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true` |

🔄 Swap `win-x64` for `osx-x64`, `linux-x64`, etc. to target other platforms.

---

## 📦 Dependencies

- **YoutubeExplode** - Grab metadata & stream URLs  
- **YoutubeExplode.Converter** - On-the-fly muxing to MP4  
- **dotenv.net** *(unused for now)* - Optional `.env` file support

---

## 📄 License

MIT – fork, tweak, redistribute however you like.
