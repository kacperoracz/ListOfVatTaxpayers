import{D as e}from"./data-qa-utils-8be7c726.js";import{n as t,r as s,y as a}from"./property-d63bb995.js";class o extends t{static get styles(){return s`
            :host {
                display: flex;
            }
        `}connectedCallback(){super.connectedCallback(),e.setLoaded(this)}disconnectedCallback(){super.disconnectedCallback(),e.removeLoaded(this)}render(){return a`<slot></slot>`}}export{o as D};
