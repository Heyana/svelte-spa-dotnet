/// <reference types="svelte" />
/// <reference types="vite/client" />

interface Window {
    chrome: {
        webview: {
            hostObjects: {
                nativeMethods: NativeMethods;
            };
        };
    };
}
interface NativeMethods {
    Greet(name: string): Promise<void>;
    Name: string | Promise<string>;
}