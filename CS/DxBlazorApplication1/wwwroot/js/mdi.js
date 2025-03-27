function addContextMenuHandler(container, tabClass, text, dotNetObject) {
    var tabElement = container.getElementsByClassName(tabClass)[0];
    if (!tabElement) return;
    tabElement.addEventListener('contextmenu', (event) => {
        event.preventDefault();
        let eventArgs = {
            clientX: event.clientX,
            clientY: event.clientY,
            screenX: event.screenX,
            screenY: event.screenY,
            offsetX: event.offsetX,
            offsetY: event.offsetY,
            pageX: event.pageX,
            pageY: event.pageY,
            button: event.button,
            buttons: event.buttons,
            ctrlKey: event.ctrlKey,
            shiftKey: event.shiftKey,
            altKey: event.altKey,
            metaKey: event.metaKey,
            detail: event.detail,
            type: event.type
        };
        dotNetObject.invokeMethodAsync("ShowContextMenu", eventArgs, text);
    });
};