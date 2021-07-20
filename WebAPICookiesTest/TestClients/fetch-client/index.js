const logIn = document.getElementById("logIn");
const logOut = document.getElementById("logOut");
const info = document.getElementById("info");
const xsfr = document.getElementById("xsfr");

logIn.addEventListener("click", () => {
  fetch("https://localhost:5001/api/auth/login", {
    method: "POST",
    credentials: "include",
    headers: {
      "Content-type": "application/json",
    },
    body: JSON.stringify({
      userName: "pperez",
      password: "abc123",
    }),
  })
    .then((res) => res.json())
    .then((data) => console.log("Success: ", data))
    .catch((error) => console.log("Error: ", error));
});

logOut.addEventListener("click", () => {
  fetch("https://localhost:5001/api/auth/logout", {
    credentials: 'include'
})
    .then((res) => res.json())
    .then((data) => console.log("Success: ", data))
    .catch((error) => console.log("Error: ", error));
});

info.addEventListener("click", () => {
  fetch("https://localhost:5001/api/info", {
    credentials: 'include'
})
    .then((res) => res.json())
    .then((data) => console.log("Success: ", data))
    .catch((error) => {
      debugger;
      console.log("Error: ", error);
    });
});

xsfr.addEventListener("click", () => {
  fetch("https://localhost:5001/api/csfr")
    .then((res) => {
      for (const header of res.headers) {
        console.log(`Name: ${header[0]}, Value:${header[1]}`);
      }
debugger
      return res;
    })
    .then((data) => {
        debugger
        console.log("Success: ", data)
    })
    .catch((error) => console.log("Error: ", error));
});
