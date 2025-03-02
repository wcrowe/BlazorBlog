# Installing Tailwind CSS v4 in a Blazor v9 WebApp

*Author: William H. Noel*  
*Published: 12 Feb 2025*  
*Source: [BillTalksTooMuch](https://www.billtalkstoomuch.com/2025/02/12/installing-tailwind-css-v4-in-a-blazor-webapp/)*

I had a challenging experience with Tailwind CSS until I discovered up-to-date tutorials from some YouTube contributors (listed at the end of this post). It seems that AI hasn't quite caught up with the latest developments.

I'm using Windows 11, JetBrains Rider, and a Blazor WebApp with `InteractiveAuto` specified, resulting in two projects.

## Steps to Install Tailwind CSS v4

1. **Download the Standalone Tailwind CSS CLI Executable:**
   - Obtain the standalone executable for the Tailwind CSS CLI from [this link](https://github.com/tailwindlabs/tailwindcss/releases). Be aware that the documentation might be outdated and still reference `tailwind.config.js`.

2. **Add the Executable to Your System Path:**
   - Place the executable in your system's PATH to simplify future access.

3. **Rename the Executable (Optional):**
   - For convenience, consider renaming the executable to something shorter, like `tw4cli`.

4. **Install Tailwind CSS:**
   - Despite some documentation suggesting that `node.js` isn't necessary when using the CLI, the `@import "tailwindcss";` directive requires Tailwind to be installed via `npm`. Therefore, install Tailwind CSS in the root of the server project (not the client project) using:
     ```bash
     npm install tailwindcss
     ```

5. **Set Up the Input CSS File:**
   - Following Chris Sainty's excellent material (note: his installation instructions are for v3), perform the following:
     - Create a `Styles` folder in the server project.
     - Inside the `Styles` folder, create an `input.css` file.
     - Add the following line to `input.css` (you might add more later):
       ```css
       @import "tailwindcss";
       ```

6. **Ensure UTF-8 Encoding for `input.css`:**
   - It's crucial that `input.css` is encoded in UTF-8. If created via the context menu in Rider, it might not be. An incorrect encoding can lead to the following error:
     ```
     Error: Invalid declaration: `@import "tailwindcss"`
     ```
   - In Rider, select the `input.css` file, then navigate to `File > File Encoding` and set it to UTF-8.

7. **Run the Tailwind CSS CLI:**
   - Open a terminal window in the solution root folder (not the server or client project folders) and execute:
     ```bash
     tw4cli -i ./<server-project-name>/styles/input.css -o ./<server-project-name>/wwwroot/app.css --watch
     ```
   - Running this command from the solution root allows the CLI to scan all child folders. Although not well-documented, in v4, you don't specify a config to locate your source; thus, it scans everything underneath the current folder. This approach ensures that classes used in both projects are included in the final `app.css`.

8. **Update `launchSettings.json` for Hot Reload:**
   - Modify your server's `launchSettings.json` file to include the following lines for hot reload. Ensure both `http` and `https` profiles are updated:
     ```json
     "hotReloadEnabled": true,
     "watchStaticFiles": true,
     ```

By running `dotnet watch` in a terminal in the server project root directory, any changes made to the client or server projects will be detected by the CLI. It will update `app.css`, and `dotnet watch` will rebuild, allowing you to see the changes immediately.

*Note:* I haven't managed to get IntelliSense working yet, but other than that, the setup functions correctly.

**YouTube Videos That Helped:**

- [Jolly Coding](https://www.youtube.com/channel/UC8butISFwT-Wl7EV0hUK0BQ): Hi, I’m James. I’m a developer advocate passionate about all things web development, especially TypeScript and React. This channel offers tutorials, tips, and insights on the latest web technologies.

- [Lukas | Web Development & Design](https://www.youtube.com/channel/UCW5YeuERMmlnqo4oq8vwUpg): Hi! I’m Luke, a self-taught Web Developer from Austria. On this channel, I share videos about HTML, CSS, Tailwind CSS, JavaScript, ReactJS, Git, GitHub, and more. The content is designed to help you become successful as a Frontend Developer, Web Developer, or Full Stack Developer. Subscribe to the channel and become a part of this journey.

*Disclaimer:* The information provided is based on personal experience and may vary depending on individual setups.

---

*For more insights and articles, visit [BillTalksTooMuch](https://www.billtalkstoomuch.com/).*
::contentReference[oaicite:0]{index=0}
 
