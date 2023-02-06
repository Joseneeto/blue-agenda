function Form({botao, eventoTeclado, cadastrar, obj, cancelar, remover, alterar}){
    return(
        <form>
            <input type="text" value={obj.name} onChange={eventoTeclado} name="name" placeholder="Nome" className="form-control"/>
            <input type="text" value={obj.email} onChange={eventoTeclado} name="email" placeholder="Email" className="form-control"/>
            <input type="text" value={obj.phone} onChange={eventoTeclado} name="phone" placeholder="Telefone" className="form-control"/>

            {
                botao
                ?
                <input type="button" value="Cadastrar" onClick={cadastrar} className="btn btn-primary"/>
                :
                <div>
                    <input type="button" onClick={alterar}  value="Alterar" className="btn btn-warning"/>
                    <input type="button" onClick={remover} value="Remover" className="btn btn-danger"/>
                    <input type="button" onClick={cancelar} value="Cancelar" className="btn btn-secondary"/>
                </div>
            }

        </form>
    )
}

export default Form;