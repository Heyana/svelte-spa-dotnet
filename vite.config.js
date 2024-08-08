import { defineConfig } from 'vite'
import { svelte } from '@sveltejs/vite-plugin-svelte'
import { viteSingleFile } from 'vite-plugin-singlefile'
import { setDefaultResultOrder } from 'dns'
import path from 'path'

setDefaultResultOrder('verbatim')

export default defineConfig({
    plugins: [
        svelte(),
        viteSingleFile({
            removeViteModuleLoader: true,
            useRecommendedBuildConfig: true,
        }),
    ],
    build: {
        outDir: 'build',
        target: 'es2019',
    },
    resolve: {
        alias: {
            '@': path.resolve('./src/lib'),
            '@assets': path.resolve('./assets'),
        },
    },
})
