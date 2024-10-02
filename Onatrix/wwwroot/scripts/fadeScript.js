export function fadeInOnScroll() {
    const fadeInElements = document.querySelectorAll('.fade');

    function isElementInViewport(el) {
        const rect = el.getBoundingClientRect();
        return (
            rect.top < (window.innerHeight || document.documentElement.clientHeight) &&
            rect.bottom > 0
        );
    }

    function onScroll() {
        fadeInElements.forEach(el => {
            if (isElementInViewport(el)) {
                el.classList.add('visible');
                el.classList.remove('hidden');
            } else {
                el.classList.remove('visible');
                el.classList.add('hidden');
            }
        });
    }

    window.addEventListener('scroll', onScroll);
    onScroll();
}
// basic css for this script
// .fade {
//    opacity: 0;
//    transition: opacity 2s ease -in -out;
//}

//        .fade.visible {
//    opacity: 1;
//}

//        .fade.hidden {
//    opacity: 0;
//}