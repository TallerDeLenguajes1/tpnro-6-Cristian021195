// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', () => {

    //VARIABLES
    let $navBar = document.querySelector('.navbar');
    let $sidePic = document.createElement('div'); $sidePic.innerHTML = `<img class="img-fluid side-ul-pic" src="https://picsum.photos/200"></img><p class="navbar-brand" href="#">Cristian Gramajo</p>`;
    let navHeigth = document.getElementsByTagName('nav')[0].clientHeight;
    let $sideNavClasses = $navBar.classList;
    let $sideDiv = document.getElementById('navbarSupportedContent');
    let $sideDivClone = $sideDiv.cloneNode(true);
    let colorTheme = obtenerColor($navBar.parentElement.classList);
    let colorFont = obtenerColorLetra($sideNavClasses);
    let sideNavState = false;
    let sideBarColor;
    if ($navBar.dataset.sideColor !== undefined) {
        sideBarColor = `bg-${$navBar.dataset.sideColor}`;
    } else {
        sideBarColor = 'bg-';
    }

    let sideBarLetterColor;
    if ($navBar.dataset.letterColor !== undefined) {
        sideBarLetterColor = $navBar.dataset.letterColor;
    } else {
        sideBarLetterColor = colorFont;
    }

    let toggleTime;
    if ($navBar.dataset.toggleDuration !== undefined) {
        toggleTime = parseInt($navBar.dataset.toggleDuration);
    } else {
        toggleTime = 300;
    }

    //ASIGNACIONES, INSERSIONES DE DOM, CLONADO DE DOM OBJECT EXISTENTE (navbar existente)
    $sideDivClone.insertAdjacentElement('afterbegin', $sidePic);
    $sideDivClone.removeAttribute('class'); $sideDivClone.removeAttribute('id');
    document.body.appendChild($sideDivClone);
    $sideDivClone.style.height = `${window.innerHeight - navHeigth}px`;
    $sideDivClone.style.top = `${navHeigth}px`;
    $sideDivClone.classList = $sideNavClasses;
    $sideDivClone.classList.remove('container'); $sideDivClone.classList.remove('navbar'); $sideDivClone.classList.remove('navbar-expand-lg'); $sideDivClone.classList.add('d-none');
    $sideDivClone.classList.add('overflow-auto');
    $sideDivClone.classList.add(`overflow`);
    $sideDivClone.classList.replace(`bg-${colorTheme}`, `${colorSideBar(sideBarColor, `bg-${colorTheme}`)}`);
    $sideDivClone.classList.replace(colorFont, `${colorSideBarLetter(sideBarLetterColor, colorFont)}`);

    //EVENTO NO REQUERIDO: por si necesitamos rescatar datos de una session y mostrar foto + nombre
    /*fetch('data.json').then(res => { return res.json() }).then(res => {
        let $sideUlPic = document.querySelector('.side-ul-pic');
        $sideUlPic.src = res.pic;
        $sideUlPic.insertAdjacentHTML('afterend', `<p class="navbar-brand" href="#">${res.username}</p>`);
    });*/

    //EVENTO RESIZE: para cerrar el sidebar y dejarlo inactivo
    window.addEventListener('resize', () => {
        $sideDivClone.style.height = `${window.innerHeight - navHeigth}px`;
        if (window.innerWidth >= 1000) {
            $sideDivClone.classList.add('d-none');
            sideNavState = false;
        }
    });

    //EVENTO CLICK (exclusivo boostrap 5)
    window.addEventListener('click', (e) => {
        if (e.target.classList[0] == 'navbar-toggler' || e.target.classList[0] == 'navbar-toggler-icon') {
            toggleSideBar(toggleTime);
        } else if (e.target.classList[0] == 'dropdown-item' || e.target.classList[0] == 'nav-link') {
        } else {
            slowSlideHide(toggleTime);
            sideNavState = !sideNavState;
        }
    });

    //DETECCION DE MOBIL
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        let direccion = [];

        document.querySelector('.navbar-toggler').style.display = 'none';

        window.addEventListener('touchstart', (e) => {
            direccion.push(e.touches[0].pageX);
        });
        window.addEventListener('touchend', (e) => {
            direccion.push(e.changedTouches[0].screenX);
            evaluarDireccion(direccion, toggleTime);
            direccion = [];
        });
    }

    //FUNCIONES
    function evaluarDireccion(direccion, time) {
        if (direccion[0] < direccion[1] && (direccion[1] / direccion[0]) > 1.5) {
            slowSlideShow(time);
        } else if (direccion[0] > direccion[1] && (direccion[0] / direccion[1]) > 1.5) {
            slowSlideHide(time);
        }
    }

    function toggleSideBar(time) {
        sideNavState = !sideNavState;
        if (sideNavState) {
            slowSlideShow(time);
        } else {
            slowSlideHide(time);
        }
    }
    function slowSlideShow(time) {
        $sideDivClone.classList.add('side-ul');
        $sideDivClone.classList.remove('d-none');

        $sideDivClone.animate([
            { transform: 'translateX(-100%)' },
            { transform: 'translateX(0%)' }
        ], {
            duration: time,
            easing: 'ease-in'
        });
        sideNavState = true;

    }
    function slowSlideHide(time) {
        $sideDivClone.animate([
            { transform: 'translateX(0%)' },
            { transform: 'translateX(-100%)' }
        ], {
            duration: time,
            easing: 'ease-in'
        });
        setTimeout(() => {
            $sideDivClone.classList.add('d-none');
            sideNavState = false;
        }, time - 50);
    }

    function colorSideBar(newColor, defaultColor) {
        if (newColor != "bg-" && newColor != "") {
            return newColor;
        } else {
            return defaultColor;
        }
    }
    function colorSideBarLetter(newColor, defaultColor) {
        if (newColor != "") {
            return newColor;
        } else {
            return defaultColor;
        }
    }
    function obtenerColorLetra(domTokenListColor) {
        if (domTokenListColor.contains('navbar-dark')) {
            return 'navbar-dark';
        } else if (domTokenListColor.contains('navbar-light')) {
            return 'navbar-light';
        }
    }

    function obtenerColor(domTokenListColor) {
        let picker;
        if (domTokenListColor.contains('bg-primary')) {
            picker = 'primary';
        } else if (domTokenListColor.contains('bg-secondary')) {
            picker = 'secondary';
        } else if (domTokenListColor.contains('bg-info')) {
            picker = 'info';
        } else if (domTokenListColor.contains('bg-danger')) {
            picker = 'danger';
        } else if (domTokenListColor.contains('bg-warning')) {
            picker = 'warning';
        } else if (domTokenListColor.contains('bg-success')) {
            picker = 'success';
        } else if (domTokenListColor.contains('bg-light')) {
            picker = 'light';
        } else if (domTokenListColor.contains('bg-white')) {
            picker = 'white';
        } else if (domTokenListColor.contains('bg-dark')) {
            picker = 'dark';
        }
        return picker;
    }
});
