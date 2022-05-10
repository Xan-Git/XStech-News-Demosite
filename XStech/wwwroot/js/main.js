const newsBtns = [...document.querySelectorAll('.dropdown-item')];
const newsLinks = [...document.querySelectorAll('.dropdown-link')];
const newsLists = [...document.querySelectorAll('.news-list')];
const newsCards = initNewsCards();
const newsToggler = document.querySelector('.dropdown-toggle');
const newsContainer = document.querySelector('.dropdown');
const navToggler = document.querySelector('.nav-toggler');
const navContainer = document.querySelector('.nav-container');

// SHOW ONLY NEWS TAB THAT IS HOVERED OVER / SELECTED
newsBtns.forEach((btn) => {
    btn.addEventListener('mouseenter', () => {

        const i = newsBtns.indexOf(btn);
        const otherLists = newsLists.filter(n => newsLists.indexOf(n) != i);
        const activeList = newsLists[i];

        otherLists.forEach(list => newsListOff(list));
        newsListOn(activeList);
    });
});

newsBtns.forEach((btn) => {
    btn.addEventListener('mouseenter', () => {
        const i = newsBtns.indexOf(btn);

        btn.dataset.active = "active";
        newsLinks[i].dataset.active = "active";
        newsBtns.filter(n => newsBtns.indexOf(n) != i)
            .forEach(n => n.dataset.active = "off");
        newsLinks.filter(n => newsLinks.indexOf(n) != i)
            .forEach(n => n.dataset.active = "off");

        newsCards.filter(cardList => newsCards.indexOf(cardList) != i)
            .forEach(cardlist => cardlist.forEach(card => card.dataset.active = "off"));

        newsCards[i].forEach(card => card.dataset.active = "active");
    });
});

newsToggler.addEventListener('mouseenter', () => {
    newsCards[0].forEach(card => card.dataset.active = "active");
    newsBtns[0].dataset.active = "active";
    newsLinks[0].dataset.active = "active";

    newsCards.filter(cardList => newsCards.indexOf(cardList) != 0)
        .forEach(cardlist => cardlist.forEach(card => card.dataset.active = "off"));
    newsBtns.filter(n => newsBtns.indexOf(n) != 0)
        .forEach(n => n.dataset.active = "off");
    newsLinks.filter(n => newsLinks.indexOf(n) != 0)
        .forEach(n => n.dataset.active = "off");
})





// TRANSITION FOR NEWSBAR
newsToggler.addEventListener('mouseover', () => {
    newsLists.forEach(list => newsListOff(list));
    newsListOn(newsLists[0]);
});

newsToggler.addEventListener('mouseenter', () => {
    newsToggler.dataset.hovered = 'on';
    newsContainer.dataset.fade = 'in';
});

newsToggler.addEventListener('mouseleave', () => {
    newsToggler.dataset.hovered = 'off';
    newsContainer.dataset.fade = 'out';
});

newsContainer.addEventListener('mouseenter', () => {
    newsContainer.dataset.fade = 'in';
});

newsContainer.addEventListener('mouseleave', () => {
    newsContainer.dataset.fade = 'out';
});

newsContainer.addEventListener('transitionend', () => {
    if (newsContainer.dataset.fade == 'out') {
        newsLists.forEach(list => newsListOff(list));
    }
});



// MOBILE NAV ANIMATIONS
navToggler.addEventListener('click', () => {
    if (navToggler.dataset.expanded == 'expanded') {
        navToggler.dataset.expanded = '';
        navContainer.dataset.expanded = '';
    }
    else {
        navToggler.dataset.expanded = 'expanded';
        navContainer.dataset.expanded = 'expanded';
    }
});



function newsListOff(list) {
    list.classList.remove('news-active');
    list.classList.add('news-inactive');
}

function newsListOn(list) {
    list.classList.remove('news-inactive');
    list.classList.add('news-active');
}


function initNewsCards() {
    const newsCards = [...document.querySelectorAll('.news-card')];
    const rowOne = [...newsCards.slice(0, 4)];
    const rowTwo = [...newsCards.slice(4, 8)];
    const rowThree = [...newsCards.slice(8, 12)];
    const rowFour = [...newsCards.slice(12, 16)];
    const rowFive = [...newsCards.slice(16, 20)];

    return [rowOne, rowTwo, rowThree, rowFour, rowFive];
}