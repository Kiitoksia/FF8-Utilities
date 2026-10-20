// Helpers for the v2 UI (imported as an ES module via JS interop)

let beepsCancelled = false;

export function playBeep(url, count, intervalMs, delayMs) {
    beepsCancelled = false;
    return new Promise(resolve => {
        setTimeout(() => {
            let played = 0;
            const play = () => {
                if (beepsCancelled) { resolve(); return; }
                new Audio(url).play().catch(() => { });
                played++;
                if (played < count) {
                    setTimeout(play, intervalMs);
                } else {
                    resolve();
                }
            };
            play();
        }, delayMs);
    });
}

export function pauseBeeps() {
    beepsCancelled = true;
}

export function vibrate(pattern) {
    try {
        if (navigator.vibrate) navigator.vibrate(pattern);
    } catch { }
}

export async function copyText(text) {
    try {
        await navigator.clipboard.writeText(text);
        return true;
    } catch {
        return false;
    }
}

// Returns the recovery box value if it is focused, "" if nothing in particular is focused,
// or null if another control has focus (so Enter belongs to that control instead).
export function timerEnterTarget() {
    const a = document.activeElement;
    if (!a || a === document.body) return "";
    if (a.classList && a.classList.contains("v-timer-input")) return a.value ?? "";
    return null;
}

export function historyBack() {
    history.back();
}

// ---------- Scroll wheel picker (Caraway poles on phone) ----------

const wheelHandlers = new WeakMap();

function wheelItemHeight(el) {
    const item = el.querySelector(".it");
    return item ? item.offsetHeight : 36;
}

export function initWheel(el, dotNetRef, index) {
    if (!el) return;
    el.scrollTop = index * wheelItemHeight(el);
    let timer = null;
    const onScroll = () => {
        clearTimeout(timer);
        timer = setTimeout(() => {
            const i = Math.round(el.scrollTop / wheelItemHeight(el));
            dotNetRef.invokeMethodAsync("OnWheelIndex", i);
        }, 120);
    };
    el.addEventListener("scroll", onScroll, { passive: true });
    el.addEventListener("scrollend", onScroll, { passive: true });
    wheelHandlers.set(el, onScroll);
}

export function setWheel(el, index) {
    if (!el) return;
    el.scrollTo({ top: index * wheelItemHeight(el), behavior: "smooth" });
}

export function disposeWheel(el) {
    if (!el) return;
    const handler = wheelHandlers.get(el);
    if (handler) {
        el.removeEventListener("scroll", handler);
        el.removeEventListener("scrollend", handler);
    }
    wheelHandlers.delete(el);
}
