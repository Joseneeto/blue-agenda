import logo from './assets/logo.png'
function Header(){

    return (
        <header>
            <div className="blue-logo-container">
                <img src={logo} alt="logo.png" />
                <h1>Agenda</h1>
            </div>
        </header >
    )

}

export default Header;