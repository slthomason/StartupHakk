//Custom Events API

window.dispatchEvent(new CustomEvent('mycustomevent', {
    detail: {
        msg: 'Hello'
    }
}));


window.addEventListener('mycustomevent', (evt) => {
    console.log(evt.detail.msg); // Hello
});


//Using the Inbuilt Sanitizer API
const rawHTML = await getRawHTMLFromServer();
docArea.innerHTML = rawHTML;


docArea.innerHTML = sanitize(rawHTML); // removes <script>, etc..

const sanitizer = new Sanitizer();
const rawHTML = await getRawHTMLFromServer();

docArea.replaceChildren(sanitizer.sanitizeFor('div', rawHTML));




//DOM Manipulation and Traversal API Shortcuts
headerElm.classList.replace('cl-green', 'cl-red');
headerElm.classList.toggle('active');


const activeStepNodes = document.querySelectorAll('.app .steps li.active');


const linkNodes = document.links;

const titleNode = mainSection.closest('.title');
titleNode.after(subTitleNode);
titleNode.prepend(bulletNode);


//Helpful Events for Modern Apps

document.addEventListener('visibilitychange', () => {
    console.log(document.visibilityState);   // 'visible' or 'hidden' 
});


document.addEventListener('scrollend', async () => {
    await loadItems(); 
});

window.addEventListener('online', () => {
    console.log('online');
});

window.addEventListener('offline', () => {
    console.log('offline');
});


//WebAssembly and Worker APIs for the Modern Web

/*export fn add(a: i32, b: i32) i32 {
    return a + b;
}*/


//Command to generate a WASM File: zig build-lib -target wasm32-freestanding -dynamic add.zig 

/*
<html>
<body>
  <script>
    fetch('add.wasm').then(r => r.arrayBuffer()
    ).then(bytes => WebAssembly.instantiate(bytes)
    ).then(r => {
      const add = r.instance.exports.add;
      console.log(add(10, 20));
    });
  </script>
</body>
</html>
*/



const wr = new Worker('background_task.js');
wr.onmessage = (e) => console.log(e.data);