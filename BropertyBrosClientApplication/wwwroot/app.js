﻿function updateCarousel(activeIndex) {
    const slides = document.querySelectorAll(".carousel-slide");
    slides.forEach((slide, index) => {
        if (index === activeIndex) {
            slide.classList.add("active");
        } else {
            slide.classList.remove("active");
        }
    });
}

/*Author: Calvin* /\ /

/*Author: Daniel*/
function goToTopOfPage() {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
}

