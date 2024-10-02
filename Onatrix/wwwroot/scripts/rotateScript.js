export function rotateOnScroll() {
    const rotateElements = document.querySelectorAll('.rotate');

    function isElementInViewport(el) {
        const rect = el.getBoundingClientRect();
        return (
            rect.top < (window.innerHeight || document.documentElement.clientHeight) &&
            rect.bottom > 0
        );
    }

    function onScroll() {
        rotateElements.forEach(el => {
            if (isElementInViewport(el)) {
                el.classList.add('rotated');
            } else {
                el.classList.remove('rotated');
            }
        });
    }

    window.addEventListener('scroll', onScroll);
    onScroll();
}
//basic css for this effect
//.rotate {
//    perspective: 1000px;
//    transition: transform 0.6s ease - out;
//    transform: rotateY(90deg);
//    opacity: 0;
//}

//    .rotate.rotated {
//    transform: rotateY(0deg);
//    opacity: 1;
//    transition: transform 1.5s ease - out, opacity 0.3s ease - out;
//}