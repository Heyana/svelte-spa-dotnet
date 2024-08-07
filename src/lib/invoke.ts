type MethodKeys = keyof NativeMethods;

export async function invoke<T>(method: MethodKeys, args: Record<string, any> = {}): Promise<T | void> {
    if (window.chrome && window.chrome.webview && window.chrome.webview.hostObjects && window.chrome.webview.hostObjects.nativeMethods) {
        const hostObject = window.chrome.webview.hostObjects.nativeMethods;
        if (hostObject[method] && typeof hostObject[method] === 'function') {
            return await hostObject[method](...Object.values(args));
        } else {
            console.error(`Method ${method} does not exist on hostObject.`);
        }
    } else {
        console.error('Host object is not available.');
    }
}