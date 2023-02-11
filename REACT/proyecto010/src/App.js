import logo from './logo.svg';
import './App.css';
import { useState, useEffect } from 'react';

function App() {

  const [articulos, setArticulos] = useState([])
  const [recuperado, setRecuperado] = useState(false)


  function mostrarTabla() {
    return (
      <div>
        <table border="1">
          <thead>
            <tr>
              <th>Código</th>
              <th>Descripción</th>
              <th>Precio</th>
            </tr>
          </thead>
          <tbody>
            {articulos.map(art => {
              return (
                <tr key={art.codigo}>
                  <td>{art.codigo}</td>
                  <td>{art.descripcion}</td>
                  <td>{art.precio}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    );
  }

  useEffect(() => {
    fetch('https://scratchya.com.ar/react/datos.php')
      .then((response) => {
        return response.json()
      })
      .then((articulos) => {
        setArticulos(articulos)
        setRecuperado(true)
      })
  }, [])

  if (recuperado)
    return mostrarTabla()
  else
    return (<div>recuperando datos...</div>)
}

export default App