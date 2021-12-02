import{a as e}from"./rect-2684652a.js";import{L as t,D as s}from"./layouthelper-c2462bd3.js";import{R as i}from"./rafaction-bba7928b.js";class n{constructor(e,t){this.target=e,this.callback=t}get position(){return this.callback(this.target)}}class r{constructor(e,t){this.observer=null,this.elementScrollHandler=this.handleElementScroll.bind(this),this.resizeHandler=this.handleResize.bind(this),this.overflows=[],this.resizing=[],this.targetElement=null,this.rafAction=new i,this.callback=e,this.options=t}get raf(){return this.options.raf}observe(e){this.disconnect(),this.targetElement=e,this.subscribeEvents()}disconnect(){var e;this.unsubscribeEvents(),this.rafAction.cancel(),null===(e=this.observer)||void 0===e||e.disconnect(),this.observer=null}getTargetBoundingClientRect(){return this.targetElement?t.getRelativeElementRect(this.targetElement):e.Empty}subscribeEvents(){if(!this.targetElement)return;window.addEventListener("scroll",this.elementScrollHandler);const e=[],i=[];for(const n of t.getRootPathAndSelf(this.targetElement)){const t=n;if(!t)return;if(this.isInShadowDom(t))continue;new ResizeObserver(this.resizeHandler).observe(t,{box:"border-box"}),i.push(),s.isScrollable(t)&&(t.addEventListener("scroll",this.elementScrollHandler,{capture:!0}),e.push(t))}this.overflows=e,this.resizing=i}isInShadowDom(e){return e.getRootNode()instanceof ShadowRoot}unsubscribeEvents(){window.removeEventListener("scroll",this.elementScrollHandler),this.overflows.forEach((e=>{e.removeEventListener("scroll",this.elementScrollHandler)})),this.resizing.forEach((e=>{e.disconnect()}))}handleResize(e,t){this.raisePositionChanged()}handleElementScroll(e){this.raisePositionChanged()}raisePositionChanged(){this.raf?this.rafAction.execute((()=>this.raisePositionChangedCore())):this.raisePositionChangedCore()}raisePositionChangedCore(){this.callback(new n(this.targetElement,this.getTargetBoundingClientRect),this)}}export{r as P};
