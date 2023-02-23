import './App.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import Authorization from './components/authorization/authorization'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Content from './components/content/content';
import Rooms from './components/rooms/rooms';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='authorization' element={<Authorization />}></Route>
        <Route path='/' element={<Content />}>
          <Route path = '/rooms' element={<Rooms />}></Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
