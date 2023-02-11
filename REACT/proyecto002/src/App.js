import logo from './logo.svg';
import './App.css';

function mostrarTitulo(tit) {
  return (<h1>
    {tit}
  </h1>);
}

function App() {
  return (
    <div>
      {mostrarTitulo('Hola Mundo')}
      {mostrarTitulo('Fin')}
    </div>
  );
}

export default App;