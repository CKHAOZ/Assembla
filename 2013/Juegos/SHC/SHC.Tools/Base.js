function ExisteCanvas() {
    var oCanvas = document.createElement('canvas');
    return !!(oCanvas.getContext && oCanvas.getContext('2d'));
}