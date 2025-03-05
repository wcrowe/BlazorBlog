/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}",
        './**/(Layout|Pages)/*.{razor,html}', // Include only Layout and Pages folders
        "./wwwroot/**/*.{html,js}"
    ],
    theme: {
        extend: {
            colors: {
                'red': {
                    500: 'oklch(0.637 0.237 25.331)', // Your custom red-500
                },
            },
        },
    },
    plugins: [],
}