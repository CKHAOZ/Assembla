if (!('boxShadow' in document.body.style)) {
    document.body.setAttribute('class', 'noBoxShadow');
}

document.body.addEventListener("click", function (e) {
    var target = e.target;
    if (target.tagName === "INPUT" &&
		target.getAttribute('class').indexOf('liga') === -1) {
        target.select();
    }
});

(function () {
    var fontSize = document.getElementById('fontSize'),
		testDrive = document.getElementById('testDrive'),
		testText = document.getElementById('testText');

    function updateTest() {
        testDrive.innerHTML = testText.value || String.fromCharCode(160);
        if (window.icomoonLiga) {
            window.icomoonLiga(testDrive);
        }
    }

    function updateSize() {
        if (testDrive) {
            testDrive.style.fontSize = fontSize.value + 'px';
        }
    }

    if (fontSize) {
        fontSize.addEventListener('change', updateSize, false);
    }
    if (testText) {
        testText.addEventListener('input', updateTest, false);
        testText.addEventListener('change', updateTest, false);
    }

    updateSize();
}());
