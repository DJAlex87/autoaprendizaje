import {useState} from 'react';

function App() {
  const [dias,setDias]=useState(['Lunes','Miércoles'])

  function cambioDias(e) {
    const opciones = e.target.options
    const seleccionadas = []
    for (let i = 0; i < opciones.length; i++) {
      if (opciones[i].selected) {
        seleccionadas.push(opciones[i].value)
      }      
    }    
    setDias(seleccionadas)
  }

  return (
    <div>
      <p><select multiple value={dias} onChange={cambioDias}>
      <option>Lunes</option>
      <option>Martes</option>
      <option>Miércoles</option>
      <option>Jueves</option>
      <option>Viernes</option>
      <option>Sábado</option>
      <option>Domingo</option>
      </select></p>
      Días seleccionados:{dias.map((dia)=>{
          return (<p>{dia}</p>)
        }
        )}
    </div>
  );
}

export default App;