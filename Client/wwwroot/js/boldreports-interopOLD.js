// Interop file to render the Bold Report Viewer component with properties.
window.BoldReports = {
    RenderViewer: function (elementID, reportViewerOptions) {
        $("#" + elementID).boldReportViewer({
            reportPath: reportViewerOptions.reportName,
            reportServiceUrl: reportViewerOptions.serviceURL,
            parameters: reportViewerOptions.parameters,
            parameterSettings: { hideParameterBlock: true }
        });
    },
    RenderDesigner: function (elementID, reportDesignerOptions) {
        $("#" + elementID).boldReportDesigner({
            serviceUrl: reportDesignerOptions.serviceURL
        });
    },
    Export: function (node, objectFromDotNet) {
        node.textContent = JSON.stringify(objectFromDotNet);
        location.href = 'api/ReportViewer/Export?Parameter=' + node.textContent;
    }
}
function jsSaveAsFile(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function jsOpenIntoNewTab(name, byteBase64) {
    var blob = b64toBlob(byteBase64);
    var blobURL = URL.createObjectURL(blob);
    var newWindow = window.open(blobURL, "_blank");
    newWindow.name = name;
}

function directprint(name, byteBase64) {
    var blob = b64toBlob(byteBase64);
    var blobURL = URL.createObjectURL(blob);
    //var newWindow = window.open(blobURL, "_blank");

    //var newWindow = window.open(blobURL);
    //newWindow.onload = () => { newWindow.print(); }
    var iframe = document.createElement('iframe');
    iframe.style.display = 'none';
    iframe.src = blobURL;
    document.body.appendChild(iframe);

    iframe.contentWindow.onload = () => {
        iframe.contentWindow.print();
    }
}

function b64toBlob(b64Data) {
    sliceSize = 512;

    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);

        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    var blob = new Blob(byteArrays, { type: 'application/pdf;base64' });
    return blob;
}