let handler = null;

const serializeEvent = (e) => ({
    key: e.key,
    code: e.keyCode.toString(),
    location: e.location,
    repeat: e.repeat,
    ctrlKey: e.ctrlKey,
    shiftKey: e.shiftKey,
    altKey: e.altKey,
    metaKey: e.metaKey,
    type: e.type
});

export function addKeyboardListener(dotNetRef) {
    removeKeyboardListener();
    handler = e => dotNetRef.invokeMethodAsync('HandleKeyDown', serializeEvent(e));
    document.addEventListener('keydown', handler);
}

export function removeKeyboardListener() {
    if (!handler) return;
    document.removeEventListener('keydown', handler);
    handler = null;
}

export function initAutoplayVideos() {
    document.querySelectorAll('video[autoplay]').forEach(v => {
        v.muted = true;
        v.play().catch(() => { });
    });
}

export async function copyToClipboard(text) {
    await navigator.clipboard.writeText(text);
}