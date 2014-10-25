// Copyright (c) 2014 Gold Experience TeamDev
//
// First Fantasy for Mobile version: 1.3
// Author: Gold Experience TeamDev (http://www.ge-team.com/)
// Support: geteamdev@gmail.com
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

/*
TERMS OF USE - EASING EQUATIONS#
Open source under the BSD License.
Copyright (c)2001 Robert Penner
All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of the author nor the names of contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

#region Namespaces

using UnityEngine;
using System.Collections;

#endregion

/***************
* FollowObject class
* Convert easetype between Hotween, Leantween and iTween tweeners.
**************/

public class FollowObject : MonoBehaviour {	
	
	#region Variables
		// Target object to follow
		public Transform m_Target = null;
		
		// Directions to enable/disable
		public bool m_TranslateXPosition = true;
		public bool m_TranslateYPosition = false;
		public bool m_TranslateZPosition = true;
	
		Bounds m_Bounds;
		Vector3 m_DifCenter;
	#endregion
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################

	#region Component Segments
	
		// Use this for initialization
		void Start () {		
			if(m_Target!=null)
			{
				// Target object has renderer mesh
				if(m_Target.renderer!=null)
				{
					// Find a center of bounds
					m_Bounds = m_Target.renderer.bounds;
					foreach (Transform child in m_Target)
					{
					    m_Bounds.Encapsulate(child.gameObject.renderer.bounds);
					}
				}
				// No renderer mesh in target object
				else
				{
					// Find a center of bounds
					Vector3 center = Vector3.zero;				
					foreach (Transform child in m_Target)
					{
					    center += child.gameObject.renderer.bounds.center;
					}
					
					// Center is average center of children
					center /= m_Target.childCount;
					
					// Calculate the bounds by creating a zero sized 'Bounds'
					m_Bounds = new Bounds(center,Vector3.zero); 				
					foreach (Transform child in m_Target)
					{
					    m_Bounds.Encapsulate(child.gameObject.renderer.bounds);   
					}
				}
				
				// Set m_DifCenter
				m_DifCenter = m_Bounds.center - m_Target.transform.position;
			}
		}
		
		// Update is called once per frame
		void Update () {		
			// Make a move if any TranslatePosition is set
			if(m_TranslateXPosition==true || m_TranslateYPosition==true || m_TranslateZPosition==true)
			{
				// Keep current position
				float x = transform.position.x;
				float y = transform.position.y;
				float z = transform.position.z;
				
				// Set position to target object
				if(m_TranslateXPosition==true)
					x = m_Target.transform.position.x + m_DifCenter.x;
				if(m_TranslateYPosition==true)
					y = m_Target.transform.position.y + m_DifCenter.y;
				if(m_TranslateZPosition==true)
					z = m_Target.transform.position.z + m_DifCenter.z;
					
				// Move this object
				transform.position = new Vector3(x, y, z);
			}
		}
	
	#endregion {Component Segments}
}

				
