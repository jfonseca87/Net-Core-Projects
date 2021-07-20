function onScanSuccess(qrCodeMessage) {
    alert(`The message in qr code is ${qrCodeMessage}`);
}

function createScanner() {
    let html5QRScanner = new Html5QrcodeScanner("scanner", { fps: 10, qrbox: 150 });
    html5QRScanner.render()
}