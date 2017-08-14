/**
	 * jQuery MD5 hash algorithm function
	 * 
	 * 	<code>
	 * 		Calculate the md5 hash of a String 
	 * 		String $.md5 ( String str )
	 * 	</code>
	 * 
	 * Calculates the MD5 hash of str using the » RSA Data Security, Inc. MD5 Message-Digest Algorithm, and returns that hash. 
	 * MD5 (Message-Digest algorithm 5) is a widely-used cryptographic hash function with a 128-bit hash value. MD5 has been employed in a wide variety of security applications, and is also commonly used to check the integrity of data. The generated hash is also non-reversable. Data cannot be retrieved from the message digest, the digest uniquely identifies the data.
	 * MD5 was developed by Professor Ronald L. Rivest in 1994. Its 128 bit (16 byte) message digest makes it a faster implementation than SHA-1.
	 * This script is used to process a variable length message into a fixed-length output of 128 bits using the MD5 algorithm. It is fully compatible with UTF-8 encoding. It is very useful when u want to transfer encrypted passwords over the internet. If you plan using UTF-8 encoding in your project don't forget to set the page encoding to UTF-8 (Content-Type meta tag). 
	 * This function orginally get from the WebToolkit and rewrite for using as the jQuery plugin.
	 * 
	 * Example
	 * 	Code
	 * 		<code>
	 * 			$.md5("I'm Persian."); 
	 * 		</code>
	 * 	Result
	 * 		<code>
	 * 			"b8c901d0f02223f9761016cfff9d68df"
	 * 		</code>
	 * 
	 * @alias Muhammad Hussein Fattahizadeh < muhammad [AT] semnanweb [DOT] com >
	 * @link http://www.semnanweb.com/jquery-plugin/md5.html
	 * @see http://www.webtoolkit.info/
	 * @license http://www.gnu.org/licenses/gpl.html [GNU General Public License]
	 * @param {jQuery} {md5:function(string))
	 * @return string
	 */

(function(e){var t=function(e,t){return e<<t|e>>>32-t},n=function(e,t){var n,r,i,s,o;return i=e&2147483648,s=t&2147483648,n=e&1073741824,r=t&1073741824,o=(e&1073741823)+(t&1073741823),n&r?o^2147483648^i^s:n|r?o&1073741824?o^3221225472^i^s:o^1073741824^i^s:o^i^s},r=function(e,t,n){return e&t|~e&n},i=function(e,t,n){return e&n|t&~n},s=function(e,t,n){return e^t^n},o=function(e,t,n){return t^(e|~n)},u=function(e,i,s,o,u,a,f){return e=n(e,n(n(r(i,s,o),u),f)),n(t(e,a),i)},a=function(e,r,s,o,u,a,f){return e=n(e,n(n(i(r,s,o),u),f)),n(t(e,a),r)},f=function(e,r,i,o,u,a,f){return e=n(e,n(n(s(r,i,o),u),f)),n(t(e,a),r)},l=function(e,r,i,s,u,a,f){return e=n(e,n(n(o(r,i,s),u),f)),n(t(e,a),r)},c=function(e){var t,n=e.length,r=n+8,i=(r-r%64)/64,s=(i+1)*16,o=Array(s-1),u=0,a=0;while(a<n)t=(a-a%4)/4,u=a%4*8,o[t]=o[t]|e.charCodeAt(a)<<u,a++;return t=(a-a%4)/4,u=a%4*8,o[t]=o[t]|128<<u,o[s-2]=n<<3,o[s-1]=n>>>29,o},h=function(e){var t="",n="",r,i;for(i=0;i<=3;i++)r=e>>>i*8&255,n="0"+r.toString(16),t+=n.substr(n.length-2,2);return t},p=function(e){e=e.replace(/\x0d\x0a/g,"\n");var t="";for(var n=0;n<e.length;n++){var r=e.charCodeAt(n);r<128?t+=String.fromCharCode(r):r>127&&r<2048?(t+=String.fromCharCode(r>>6|192),t+=String.fromCharCode(r&63|128)):(t+=String.fromCharCode(r>>12|224),t+=String.fromCharCode(r>>6&63|128),t+=String.fromCharCode(r&63|128))}return t};e.extend({md5:function(e){var t=Array(),r,i,s,o,d,v,m,g,y,b=7,w=12,E=17,S=22,x=5,T=9,N=14,C=20,k=4,L=11,A=16,O=23,M=6,_=10,D=15,P=21;e=p(e),t=c(e),v=1732584193,m=4023233417,g=2562383102,y=271733878;for(r=0;r<t.length;r+=16)i=v,s=m,o=g,d=y,v=u(v,m,g,y,t[r+0],b,3614090360),y=u(y,v,m,g,t[r+1],w,3905402710),g=u(g,y,v,m,t[r+2],E,606105819),m=u(m,g,y,v,t[r+3],S,3250441966),v=u(v,m,g,y,t[r+4],b,4118548399),y=u(y,v,m,g,t[r+5],w,1200080426),g=u(g,y,v,m,t[r+6],E,2821735955),m=u(m,g,y,v,t[r+7],S,4249261313),v=u(v,m,g,y,t[r+8],b,1770035416),y=u(y,v,m,g,t[r+9],w,2336552879),g=u(g,y,v,m,t[r+10],E,4294925233),m=u(m,g,y,v,t[r+11],S,2304563134),v=u(v,m,g,y,t[r+12],b,1804603682),y=u(y,v,m,g,t[r+13],w,4254626195),g=u(g,y,v,m,t[r+14],E,2792965006),m=u(m,g,y,v,t[r+15],S,1236535329),v=a(v,m,g,y,t[r+1],x,4129170786),y=a(y,v,m,g,t[r+6],T,3225465664),g=a(g,y,v,m,t[r+11],N,643717713),m=a(m,g,y,v,t[r+0],C,3921069994),v=a(v,m,g,y,t[r+5],x,3593408605),y=a(y,v,m,g,t[r+10],T,38016083),g=a(g,y,v,m,t[r+15],N,3634488961),m=a(m,g,y,v,t[r+4],C,3889429448),v=a(v,m,g,y,t[r+9],x,568446438),y=a(y,v,m,g,t[r+14],T,3275163606),g=a(g,y,v,m,t[r+3],N,4107603335),m=a(m,g,y,v,t[r+8],C,1163531501),v=a(v,m,g,y,t[r+13],x,2850285829),y=a(y,v,m,g,t[r+2],T,4243563512),g=a(g,y,v,m,t[r+7],N,1735328473),m=a(m,g,y,v,t[r+12],C,2368359562),v=f(v,m,g,y,t[r+5],k,4294588738),y=f(y,v,m,g,t[r+8],L,2272392833),g=f(g,y,v,m,t[r+11],A,1839030562),m=f(m,g,y,v,t[r+14],O,4259657740),v=f(v,m,g,y,t[r+1],k,2763975236),y=f(y,v,m,g,t[r+4],L,1272893353),g=f(g,y,v,m,t[r+7],A,4139469664),m=f(m,g,y,v,t[r+10],O,3200236656),v=f(v,m,g,y,t[r+13],k,681279174),y=f(y,v,m,g,t[r+0],L,3936430074),g=f(g,y,v,m,t[r+3],A,3572445317),m=f(m,g,y,v,t[r+6],O,76029189),v=f(v,m,g,y,t[r+9],k,3654602809),y=f(y,v,m,g,t[r+12],L,3873151461),g=f(g,y,v,m,t[r+15],A,530742520),m=f(m,g,y,v,t[r+2],O,3299628645),v=l(v,m,g,y,t[r+0],M,4096336452),y=l(y,v,m,g,t[r+7],_,1126891415),g=l(g,y,v,m,t[r+14],D,2878612391),m=l(m,g,y,v,t[r+5],P,4237533241),v=l(v,m,g,y,t[r+12],M,1700485571),y=l(y,v,m,g,t[r+3],_,2399980690),g=l(g,y,v,m,t[r+10],D,4293915773),m=l(m,g,y,v,t[r+1],P,2240044497),v=l(v,m,g,y,t[r+8],M,1873313359),y=l(y,v,m,g,t[r+15],_,4264355552),g=l(g,y,v,m,t[r+6],D,2734768916),m=l(m,g,y,v,t[r+13],P,1309151649),v=l(v,m,g,y,t[r+4],M,4149444226),y=l(y,v,m,g,t[r+11],_,3174756917),g=l(g,y,v,m,t[r+2],D,718787259),m=l(m,g,y,v,t[r+9],P,3951481745),v=n(v,i),m=n(m,s),g=n(g,o),y=n(y,d);var H=h(v)+h(m)+h(g)+h(y);return H.toLowerCase()}})})(jQuery);