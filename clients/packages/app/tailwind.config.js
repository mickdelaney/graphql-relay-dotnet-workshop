// tailwind.config.js
const defaultTheme = require('tailwindcss/defaultTheme')

module.exports = {
  mode: 'jit',
  purge: [
    './public/**/*.html',
    './src/**/*.{ts,tsx}',
    '../ui/src/**/*.{ts,tsx}',
  ],
  theme: {
    extend: {
      fontFamily: {
        sans: ['Inter var', ...defaultTheme.fontFamily.sans],
      },
      height: {
        screen50: '50vh',
        screen60: '60vh',
        screen75: '75vh',
        screen80: '80vh',
      },
    },
  },
}
