function UnityProgress (dom) {
	
	this.progress = 0.0;
	this.message = "";
	this.dom = dom;
	this.loadingbar = document.getElementById("loadingbar");
	this.loadingtext = document.getElementById("loadertext");
	var parent = dom.parentNode;
	
	this.SetProgress = function (progress) { 
		if (this.progress < progress)
		this.progress = progress;
		this.Update();
	}
	
	this.SetMessage = function (message) { 
		this.message = message; 
		this.Update();
	}
	
	this.Clear = function() {
		this.loadingbar.style.display = "none";
		this.loadingtext.style.display = "none";
	}
	
	this.Update = function() {
		this.loadingbar.value = Math.min(this.progress, 1);
		this.loadingtext.innerHTML = this.message;
	}
	
	this.Update ();
	
}