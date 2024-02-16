
export function beforeRequest() {
    client.log("BEFORE REQUEST");
}

export function afterRequest() {
    client.log("AFTER REQUEST");
    
    client.log(response.body)
}