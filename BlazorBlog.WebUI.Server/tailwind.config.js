/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Pages/**/*.razor",       // Blazor pages
        "./Components/**/*.razor",  // General components
        "./Shared/**/*.razor",      // Shared components
        "./Features/**/*.razor",    // Features folder components ✅ ADDED
        "./**/*.razor.css",         // ✅ ADDED TO PICK UP COMPONENT-SCOPED CSS
        "./**/*.html",
        "./wwwroot/**/*.js",
    ],
    theme: {
        extend: {
            colors: {
                red: {
                    500: 'oklch(0.637 0.237 25.331)', // Custom red-500 color
                },
            },
        },
    },
    plugins: [],
};
