
function setFocusToElement(id) {
    var element = document.getElementById(id);
    if (element) {
        element.focus();
    }
}

function addEnterKeyListenerToGrid(dotNetHelper, gridSelector) {
    var gridElement = document.querySelector(gridSelector);
    if (gridElement) {
        gridElement.addEventListener("keydown", function (e) {
            if (e.key === "Enter") {
                e.preventDefault();
                e.stopPropagation();
                console.log("Enter pressed");
                dotNetHelper.invokeMethodAsync('CloseDialog');
            }
        });
    }
}



function focusFirstGridRow(gridId) {
    const focusableElement = document.querySelector(`#${gridId} .e-row:first-child .e-rowcell`);
    if (focusableElement) {
        focusableElement.focus();
    } else {
        const firstRow = document.querySelector(`#${gridId} .e-row:first-child`);
        if (firstRow && firstRow.hasAttribute('tabindex')) {
            firstRow.focus();
        }
    }
}
function initializeKeyPressListener(dotNetObjectRef) {
    document.addEventListener('keydown', function (event) {
        const isFunctionKey = event.key.startsWith('F') && parseInt(event.key.substring(1)) >= 1 && parseInt(event.key.substring(1)) <= 12;
        const isCorrectPath = window.location.pathname === '/TaxInvoice' || window.location.pathname.startsWith('/TaxInvoice/');

        if (event.shiftKey && isFunctionKey && isCorrectPath) {
            event.preventDefault();
            dotNetObjectRef.invokeMethodAsync('HandleKeyboardEventOfToolBar', event.key);
        }
    });
}
function focusAndTriggerEvent(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.focus();
        element.click(); // Trigger click event
    }
}
function interceptTabKey(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.addEventListener('keydown', function (e) {
            if (e.key === 'Tab') {
                e.preventDefault(); // Prevent default tab behavior
                // Optionally, trigger any other custom behavior here
            }
        });
    }
}




