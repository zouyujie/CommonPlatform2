$.extend(!0,$.fn.dataTable.defaults,{dom:"<'row'<'col-md-6 col-sm-6'l><'col-md-6 col-sm-6'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-5'i><'col-md-7 col-sm-7'p>>",language:{lengthMenu:" _MENU_ records ",paginate:{previous:"Prev",next:"Next",page:"Page",pageOf:"of"}},pagingType:"bootstrap_number"}),$.extend($.fn.dataTableExt.oStdClasses,{sWrapper:"dataTables_wrapper",sFilterInput:"form-control input-sm input-small input-inline",sLengthSelect:"form-control input-sm input-xsmall input-inline"}),$.fn.dataTable.defaults.renderer="bootstrap",$.fn.dataTable.ext.renderer.pageButton.bootstrap=function(e,t,n,r,i,s){var o=new $.fn.dataTable.Api(e),u=e.oClasses,a=e.oLanguage.oPaginate,f,l,c=function(t,r){var h,p,d,v,m=function(e){e.preventDefault(),e.data.action!=="ellipsis"&&o.page(e.data.action).draw(!1)};for(h=0,p=r.length;h<p;h++){v=r[h];if($.isArray(v))c(t,v);else{f="",l="";switch(v){case"ellipsis":f="&hellip;",l="disabled";break;case"first":f=a.sFirst,l=v+(i>0?"":" disabled");break;case"previous":f=a.sPrevious,l=v+(i>0?"":" disabled");break;case"next":f=a.sNext,l=v+(i<s-1?"":" disabled");break;case"last":f=a.sLast,l=v+(i<s-1?"":" disabled");break;default:f=v+1,l=i===v?"active":""}f&&(d=$("<li>",{"class":u.sPageButton+" "+l,"aria-controls":e.sTableId,tabindex:e.iTabIndex,id:n===0&&typeof v=="string"?e.sTableId+"_"+v:null}).append($("<a>",{href:"#"}).html(f)).appendTo(t),e.oApi._fnBindAction(d,{action:v},m))}}};c($(t).empty().html('<ul class="pagination"/>').children("ul"),r)},$.fn.dataTableExt.oApi.fnPagingInfo=function(e){return{iStart:e._iDisplayStart,iEnd:e.fnDisplayEnd(),iLength:e._iDisplayLength,iTotal:e.fnRecordsTotal(),iFilteredTotal:e.fnRecordsDisplay(),iPage:e._iDisplayLength===-1?0:Math.ceil(e._iDisplayStart/e._iDisplayLength),iTotalPages:e._iDisplayLength===-1?0:Math.ceil(e.fnRecordsDisplay()/e._iDisplayLength)}},$.extend($.fn.dataTableExt.oPagination,{bootstrap_full_number:{fnInit:function(e,t,n){var r=e.oLanguage.oPaginate,i=function(t){t.preventDefault(),e.oApi._fnPageChange(e,t.data.action)&&n(e)};$(t).append('<ul class="pagination"><li class="prev disabled"><a href="#" title="'+r.sFirst+'"><i class="fa fa-angle-double-left"></i></a></li>'+'<li class="prev disabled"><a href="#" title="'+r.sPrevious+'"><i class="fa fa-angle-left"></i></a></li>'+'<li class="next disabled"><a href="#" title="'+r.sNext+'"><i class="fa fa-angle-right"></i></a></li>'+'<li class="next disabled"><a href="#" title="'+r.sLast+'"><i class="fa fa-angle-double-right"></i></a></li>'+"</ul>");var s=$("a",t);$(s[0]).bind("click.DT",{action:"first"},i),$(s[1]).bind("click.DT",{action:"previous"},i),$(s[2]).bind("click.DT",{action:"next"},i),$(s[3]).bind("click.DT",{action:"last"},i)},fnUpdate:function(e,t){var n=5,r=e.oInstance.fnPagingInfo(),i=e.aanFeatures.p,s,o,u,a,f,l=Math.floor(n/2);r.iTotalPages<n?(a=1,f=r.iTotalPages):r.iPage<=l?(a=1,f=n):r.iPage>=r.iTotalPages-l?(a=r.iTotalPages-n+1,f=r.iTotalPages):(a=r.iPage-l+1,f=a+n-1);for(s=0,iLen=i.length;s<iLen;s++){r.iTotalPages<=0?$(".pagination",i[s]).css("visibility","hidden"):$(".pagination",i[s]).css("visibility","visible"),$("li:gt(1)",i[s]).filter(":not(.next)").remove();for(o=a;o<=f;o++)u=o==r.iPage+1?'class="active"':"",$("<li "+u+'><a href="#">'+o+"</a></li>").insertBefore($("li.next:first",i[s])[0]).bind("click",function(n){n.preventDefault(),e._iDisplayStart=(parseInt($("a",this).text(),10)-1)*r.iLength,t(e)});r.iPage===0?$("li.prev",i[s]).addClass("disabled"):$("li.prev",i[s]).removeClass("disabled"),r.iPage===r.iTotalPages-1||r.iTotalPages===0?$("li.next",i[s]).addClass("disabled"):$("li.next",i[s]).removeClass("disabled")}}}}),$.extend($.fn.dataTableExt.oPagination,{bootstrap_number:{fnInit:function(e,t,n){var r=e.oLanguage.oPaginate,i=function(t){t.preventDefault(),e.oApi._fnPageChange(e,t.data.action)&&n(e)};$(t).append('<ul class="pagination"><li class="prev disabled"><a href="#" title="'+r.sPrevious+'"><i class="fa fa-angle-left"></i></a></li>'+'<li class="next disabled"><a href="#" title="'+r.sNext+'"><i class="fa fa-angle-right"></i></a></li>'+"</ul>");var s=$("a",t);$(s[0]).bind("click.DT",{action:"previous"},i),$(s[1]).bind("click.DT",{action:"next"},i)},fnUpdate:function(e,t){var n=5,r=e.oInstance.fnPagingInfo(),i=e.aanFeatures.p,s,o,u,a,f,l=Math.floor(n/2);r.iTotalPages<n?(a=1,f=r.iTotalPages):r.iPage<=l?(a=1,f=n):r.iPage>=r.iTotalPages-l?(a=r.iTotalPages-n+1,f=r.iTotalPages):(a=r.iPage-l+1,f=a+n-1);for(s=0,iLen=i.length;s<iLen;s++){r.iTotalPages<=0?$(".pagination",i[s]).css("visibility","hidden"):$(".pagination",i[s]).css("visibility","visible"),$("li:gt(0)",i[s]).filter(":not(.next)").remove();for(o=a;o<=f;o++)u=o==r.iPage+1?'class="active"':"",$("<li "+u+'><a href="#">'+o+"</a></li>").insertBefore($("li.next:first",i[s])[0]).bind("click",function(n){n.preventDefault(),e._iDisplayStart=(parseInt($("a",this).text(),10)-1)*r.iLength,t(e)});r.iPage===0?$("li.prev",i[s]).addClass("disabled"):$("li.prev",i[s]).removeClass("disabled"),r.iPage===r.iTotalPages-1||r.iTotalPages===0?$("li.next",i[s]).addClass("disabled"):$("li.next",i[s]).removeClass("disabled")}}}}),$.extend($.fn.dataTableExt.oPagination,{bootstrap_extended:{fnInit:function(e,t,n){var r=e.oLanguage.oPaginate,i=e.oInstance.fnPagingInfo(),s=function(t){t.preventDefault(),e.oApi._fnPageChange(e,t.data.action)&&n(e)};$(t).append('<div class="pagination-panel"> '+(r.page?r.page:"")+" "+'<a href="#" class="btn btn-sm default prev disabled"><i class="fa fa-angle-left"></i></a>'+'<input type="text" class="pagination-panel-input form-control input-sm input-inline input-mini" maxlenght="5" style="text-align:center; margin: 0 5px;">'+'<a href="#" class="btn btn-sm default next disabled"><i class="fa fa-angle-right"></i></a> '+(r.pageOf?r.pageOf+' <span class="pagination-panel-total"></span>':"")+"</div>");var o=$("a",t);$(o[0]).bind("click.DT",{action:"previous"},s),$(o[1]).bind("click.DT",{action:"next"},s),$(".pagination-panel-input",t).bind("change.DT",function(t){var r=e.oInstance.fnPagingInfo();t.preventDefault();var i=parseInt($(this).val());i>0&&i<=r.iTotalPages?e.oApi._fnPageChange(e,i-1)&&n(e):$(this).val(r.iPage+1)}),$(".pagination-panel-input",t).bind("keypress.DT",function(t){var r=e.oInstance.fnPagingInfo();if(t.which==13){var i=parseInt($(this).val());i>0&&i<=e.oInstance.fnPagingInfo().iTotalPages?e.oApi._fnPageChange(e,i-1)&&n(e):$(this).val(r.iPage+1),t.preventDefault()}})},fnUpdate:function(e,t){var n=5,r=e.oInstance.fnPagingInfo(),i=e.aanFeatures.p,s,o,u,a,f,l=Math.floor(n/2);r.iTotalPages<n?(a=1,f=r.iTotalPages):r.iPage<=l?(a=1,f=n):r.iPage>=r.iTotalPages-l?(a=r.iTotalPages-n+1,f=r.iTotalPages):(a=r.iPage-l+1,f=a+n-1);for(s=0,iLen=i.length;s<iLen;s++){var c=$(i[s]).parents(".dataTables_wrapper");r.iTotal<=0?$(".dataTables_paginate, .dataTables_length",c).hide():$(".dataTables_paginate, .dataTables_length",c).show(),r.iTotalPages<=0?$(".dataTables_paginate, .dataTables_length .seperator",c).hide():$(".dataTables_paginate, .dataTables_length .seperator",c).show(),$(".pagination-panel-total",i[s]).html(r.iTotalPages),$(".pagination-panel-input",i[s]).val(r.iPage+1),$("li:gt(1)",i[s]).filter(":not(.next)").remove();for(o=a;o<=f;o++)u=o==r.iPage+1?'class="active"':"",$("<li "+u+'><a href="#">'+o+"</a></li>").insertBefore($("li.next:first",i[s])[0]).bind("click",function(n){n.preventDefault(),e._iDisplayStart=(parseInt($("a",this).text(),10)-1)*r.iLength,t(e)});r.iPage===0?$("a.prev",i[s]).addClass("disabled"):$("a.prev",i[s]).removeClass("disabled"),r.iPage===r.iTotalPages-1||r.iTotalPages===0?$("a.next",i[s]).addClass("disabled"):$("a.next",i[s]).removeClass("disabled")}}}});