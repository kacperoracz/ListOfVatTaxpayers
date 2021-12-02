import{a as e}from"./_tslib-1f2a369a.js";import t from"./adaptivedropdowncomponents-b4faebee.js";import{D as n}from"./dx-dropdown-editor-base-17161962.js";import{ListBoxSelectedItemsChangedEvent as o}from"./dx-listbox-7dc6c76b.js";import{e as r}from"./property-d63bb995.js";import"./dropdowncomponents-e2820ed6.js";import"./popup-9c592b3d.js";import"./rect-2684652a.js";import"./point-9c6ab88a.js";import"./rafaction-bba7928b.js";import"./transformhelper-3935ca6a.js";import"./layouthelper-c2462bd3.js";import"./positiontracker-9570b24e.js";import"./positiontrackerobserver-5fd93b2c.js";import"./pointer-event-helper-af17dc0d.js";import"./popuproot-e58b0e44.js";import"./branch-a902b7e1.js";import"./data-qa-utils-8be7c726.js";import"./capturemanager-f28d279d.js";import"./eventhelper-dec6cde0.js";import"./dx-ui-element-834c6d10.js";import"./thumb-ae63786a.js";import"./query-44b9267f.js";import"./popupbasedialog-d87b07fb.js";import"./events-interseptor-f13f965c.js";import"./modalcomponents-ee519c08.js";import"./dom-b082d2b1.js";import"./dx-ui-handlers-bridge-4076ae57.js";import"./dx-dropdown-owner-6316b2ef.js";var i;!function(e){e.ContentOrEditorWidth="contentoreditorwidth",e.ContentWidth="contentwidth",e.EditorWidth="editorwidth"}(i||(i={}));class d extends n{constructor(){super(),this.boundOnKeyUpHandler=this.onKeyUp.bind(this),this.boundOnInputTextChangedHandler=this.onInputTextChanged.bind(this),this.boundOnDropDownSelectedItemsChangedHandler=this.onDropDownSelectedItemsChanged.bind(this),this.dropDownWidthMode=i.ContentOrEditorWidth,this.filteringEnabled=!1,this.inputGroupResizeObserver=new ResizeObserver(this.onInputGroupSizeChanged.bind(this))}connectedCallback(){super.connectedCallback(),this.addEventListener("keyup",this.boundOnKeyUpHandler)}disconnectedCallback(){var e;null===(e=this.inputElement)||void 0===e||e.removeEventListener("input",this.boundOnInputTextChangedHandler),this.inputGroupResizeObserver.disconnect(),this.removeEventListener("keyup",this.boundOnKeyUpHandler),super.disconnectedCallback()}updated(e){super.updated(e),e.has("dropDownWidthMode")&&this.prepareDropDownWidth()}onSlotChanged(e){var t;super.onSlotChanged(e),null===(t=this.inputElement)||void 0===t||t.addEventListener("input",this.boundOnInputTextChangedHandler);const n=this.getInputGroupElement();this.inputGroupResizeObserver.observe(n)}invokeKeyDownServerCommand(e){var t,n;if(!d.requireSendKeyCommandToServer(e))return super.invokeKeyDownServerCommand(e);const o={key:e.key,altKey:e.altKey,ctrlKey:e.ctrlKey||e.metaKey,inputText:null===(t=this.inputElement)||void 0===t?void 0:t.value};return null===(n=this.uiHandlersBridge)||void 0===n||n.send("invokeKeyDownCommand",o),!0}processLostFocus(){var e,t;const n={text:null===(e=this.inputElement)||void 0===e?void 0:e.value};null===(t=this.uiHandlersBridge)||void 0===t||t.send("lostFocus",n)}onKeyUp(e){var t;if("ArrowUp"===e.key||"ArrowDown"===e.key){const n={key:e.key};null===(t=this.uiHandlersBridge)||void 0===t||t.send("invokeKeyUpCommand",n)}}onInputTextChanged(e){var t;if(!this.filteringEnabled||!this.inputElement)return;null===(t=this.uiHandlersBridge)||void 0===t||t.send("invokeFilterChangedCommand",{text:this.inputElement.value})}onDropDownSelectedItemsChanged(e){e.stopPropagation();const t=e.target;null==t||t.scrollToFocusedItem(!1)}onInputGroupSizeChanged(e,t){if(e.length<1||!this.dropDownElement)return;const n=e[0].contentRect.width+"px";this.dropDownElement.desiredWidth=this.dropDownWidthMode===i.EditorWidth?n:null,this.dropDownElement.minDesiredWidth=this.dropDownWidthMode===i.ContentOrEditorWidth?n:null}ensureDropDownElement(){var e;super.ensureDropDownElement(),null===(e=this.dropDownElement)||void 0===e||e.addEventListener(o.eventName,this.boundOnDropDownSelectedItemsChangedHandler)}disposeDropDownElement(){var e;null===(e=this.dropDownElement)||void 0===e||e.removeEventListener(o.eventName,this.boundOnDropDownSelectedItemsChangedHandler),super.disposeDropDownElement()}prepareDropDownWidth(){if(this.isInitialized)switch(this.inputGroupResizeObserver.disconnect(),this.dropDownElement&&(this.dropDownElement.desiredWidth=null,this.dropDownElement.minDesiredWidth=null),this.dropDownWidthMode){case i.EditorWidth:case i.ContentOrEditorWidth:this.inputGroupResizeObserver.observe(this.getInputGroupElement())}}getInputGroupElement(){return this.querySelector(".input-group")}static requireSendKeyCommandToServer(e){switch(e.key){case"Enter":case"ArrowUp":case"ArrowDown":case"PageUp":case"PageDown":return!0;case"Home":case"End":return e.ctrlKey||e.metaKey}return!1}}e([r({type:i,attribute:"dropdown-width-mode"})],d.prototype,"dropDownWidthMode",void 0),e([r({type:Boolean,attribute:"filtering-enabled"})],d.prototype,"filteringEnabled",void 0),customElements.define("dxbl-combobox",d);const s={loadModule:function(){},adaptiveDropdownComponents:t};export{s as default};
