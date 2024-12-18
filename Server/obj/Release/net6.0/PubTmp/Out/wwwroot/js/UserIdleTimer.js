var theMainLayoutObjectRef_G;

var theUserIdleTimer_G = null;
var iTimeoutLength_G = 1000

function setupUserIdleTimer(theMainLayout, iTimeoutLength) {
    theMainLayoutObjectRef_G = theMainLayout;
    iTimeoutLength_G = iTimeoutLength;

    console.log("setupUserIdleTimer(" + iTimeoutLength_G.toString() + ")");

    document.onkeypress = resetUserIdleTimer;
    document.onmousedown = resetUserIdleTimer;
    document.ontouchstart = resetUserIdleTimer;
    document.onclick = resetUserIdleTimer;
    document.onkeypress = resetUserIdleTimer;

    // Start the timer
    resetUserIdleTimer();
}

function userTimerExpired() {
    console.log("userTimerExpired()");


    //var Logouturl = window.sessionStorage.getItem('LogoutURL').toString();
    //const Logouturl = window.sessionStorage.getItem('LogoutURL').replace('"', '');
    var Logouturl = window.sessionStorage.getItem('LogoutURL').replace('"', '').slice(0, -1);
    window.sessionStorage.clear();
    window.location.href = Logouturl;

    //window.sessionStorage.clear();
    //window.location.href = 'Index';
    resetUserIdleTimer();
}

function resetUserIdleTimer() {
    console.log("resetUserIdleTimer()");

    if (theUserIdleTimer_G) clearTimeout(theUserIdleTimer_G);

    theUserIdleTimer_G = setTimeout(userTimerExpired, iTimeoutLength_G)
}
