using System.Collections.Generic;

namespace BeatThat.UI
{
	public class PanelTransitionEqualityComparer : IEqualityComparer<PanelTransition>
	{
		public static readonly PanelTransitionEqualityComparer INSTANCE = new PanelTransitionEqualityComparer();
		
		private PanelTransitionEqualityComparer() {}
		
	    public bool Equals(PanelTransition o1, PanelTransition o2)
	    {
	        return (o1 == o2);
	    }
	
	
	    public int GetHashCode(PanelTransition o)
	    {
	        return o.GetHashCode();
	    }
	}
		
	public struct PanelTransition 
	{
		
		private static Dictionary<string, PanelTransition> PANEL_TRANSITIONS_BY_NAME = new Dictionary<string, PanelTransition>();
		
		public static readonly PanelTransition IN = new PanelTransition("in");
		public static readonly PanelTransition IN_BACK = new PanelTransition("in-back");
		public static readonly PanelTransition OUT = new PanelTransition("out");
		public static readonly PanelTransition OUT_BACK = new PanelTransition("out-back");
		
		
		public PanelTransition(string tname) 
		{
			m_name = tname.ToLower();
			
			if(PANEL_TRANSITIONS_BY_NAME.ContainsKey(m_name)) {
				throw new System.Exception("Duplicate PanelTransition name: '" + m_name + "'");
			}

			PANEL_TRANSITIONS_BY_NAME[m_name] = this;
		}
		
		public bool MatchesName(string name)
		{
			return name != null && name.ToLower().Equals(this.name);
		}
		
		public static PanelTransition Get(string name)
		{
			PanelTransition ut;
			if(PANEL_TRANSITIONS_BY_NAME.TryGetValue(name.ToLower(), out ut)) {
				return ut;
			}
			else {
				throw new System.Exception("No PanelTransition matching name '" + name + "'");
			}
		}
		
		public string name
		{
			get {
				return m_name;
			}
		}
		
		public override bool Equals(object obj)
	    {
	        return obj is PanelTransition && this.Equals((PanelTransition)obj);
	    }
	
	    public bool Equals(PanelTransition p)
	    {
	        return (this.name == p.name);
	    }
	
	    public override int GetHashCode()
	    {
			return this.name.GetHashCode();
	    }
		
		public static bool operator ==(PanelTransition lhs, PanelTransition rhs)
	    {
	        return lhs.Equals(rhs);
	    }
		
		public static bool operator !=(PanelTransition lhs, PanelTransition rhs)
		{
	        return !(lhs == rhs);
	    }
		
		override public string ToString()
		{
			return this.name.ToString();
		}

		private string m_name;
	}
}

