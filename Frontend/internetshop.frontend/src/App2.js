import React, { useState } from "react";
import Counter from "./Components/Counter";

function App2()
{
    const [value, setValue] = useState('GYDA ZOV SVO')

    return(
        <div className="App2"> 
            <Counter/>
        </div>
    );
}

export default App2;