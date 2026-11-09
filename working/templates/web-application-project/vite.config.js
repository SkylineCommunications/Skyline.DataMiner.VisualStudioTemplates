import { defineConfig } from 'vite';

export default defineConfig({
  // Relative asset paths, so the web application works independent of the URL it is hosted on.
  base: './',
  build: {
    outDir: 'dist',
    emptyOutDir: true,
  },
});
