import{ useEffect, useState } from 'react';
import './App.css';
import Form from './form';
import Header from './header';
import Table from './table';

function App() {

  //objeto contato
  const contato = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  }

  //useState
  const [btnCadastrar, setBtnCadastrar] = useState(true);

  const [contatos, setContatos] = useState([]);

  const [objContato, setObjContato] = useState(contato);

  //useEffect
  useEffect(() => {
    fetch("https://localhost:7294/api/Contato")
    .then(retorno => retorno.json())
    .then(retorno_convertido => setContatos(retorno_convertido));
  },[]);

  //obtendo os dados do formulario
  const aoDigitar = (e) => {
    setObjContato({...objContato, [e.target.name]:e.target.value});
  }

  // cadastrar contato
  const cadastrar = () => {
    fetch("https://localhost:7294/api/Contato/cadastrar", {
      method: 'post',
      body: JSON.stringify(objContato),
      headers:{
        'Content-type': 'application/json',
        'Accept': 'application/json'
      }
    })
    .then(retorno => retorno.json())
    .then(retorno_convertido => {

      if(retorno_convertido.mensagem !== undefined){
        alert(retorno_convertido.mensagem);
      }else{
        setContatos([...contatos, retorno_convertido]);
        alert("Contato cadastrado com sucesso!")
        limparFormulario();
      }

    })
  }

  // alterar contato
  const alterar = () => {
    fetch("https://localhost:7294/api/Contato/alterar/"+objContato.id, {
      method: 'put',
      body: JSON.stringify(objContato),
      headers:{
        'Content-type': 'application/json',
        'Accept': 'application/json'
      }
    })
    .then(retorno => retorno.json())
    .then(retorno_convertido => {

      if(retorno_convertido.mensagem !== undefined){
        alert(retorno_convertido.mensagem);
      }else{
        alert("Contato alterado com sucesso!")
        
        //cópia do vetor de contatos
        let vetorTemp = [...contatos];

        //indice
        let indice = vetorTemp.findIndex((c) => {
          return c.id === objContato.id
        });

        //alterar contato do vetor temporario
        vetorTemp[indice] = objContato;

        //atualizar vetor de contatos
        setContatos(vetorTemp);

        //limpar formulário
        limparFormulario();

      }

    })
  }


  // remover contato
  const remover = () => {
    fetch("https://localhost:7294/api/Contato/remover/"+objContato.id, {
      method: 'delete',
      headers:{
        'Content-type': 'application/json',
        'Accept': 'application/json'
      }
    })
    .then(retorno => retorno.json())
    .then(retorno_convertido => {

      //mensagem
      alert("Contato excluído com sucesso");

      //cópia do vetor de contatos
      let vetorTemp = [...contatos];

      //indice
      let indice = vetorTemp.findIndex((c) => {
        return c.id === objContato.id
      });

      //remover contato do vetor temporario
      vetorTemp.splice(indice, 1);

      //atualizar vetor de contatos
      setContatos(vetorTemp);

      //limpar formulário
      limparFormulario();

    })
  }

  //limpar fomulário
  const limparFormulario = () =>{
    setObjContato(contato);
    setBtnCadastrar(true);
  }

  //selecionar produto
  const selecionarProduto = (indice) => {
    setObjContato(contatos[indice]);
    setBtnCadastrar(false);
  }

  //retorno
  return (
    <div>
      <Header />
      <Form botao={btnCadastrar} eventoTeclado={aoDigitar} cadastrar={cadastrar} obj={objContato} cancelar={limparFormulario} remover={remover} alterar={alterar} />
      <Table vetor={contatos} selecionar={selecionarProduto} />
    </div>
  );
}

export default App;
