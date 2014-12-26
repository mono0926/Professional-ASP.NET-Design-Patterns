using System;
using System.Collections.Generic;
using ASPPatterns.Chap9.PeriodicRefresh.Model;

namespace ASPPatterns.Chap9.PeriodicRefresh.Repository
{
    public class EventRepository : IEventRepository
    {
        private DateTime _startTime = DateTime.Now;

        public IEnumerable<Event> FindAllSince(int eventId)
        {
            return GetAllEvents().FindAll(e => (e.Id > eventId) && (e.RealTime < DateTime.Now));
        }

        private List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            events.Add(new Event { Id = 1, Text = "Corner taken left-footed by Jamie Hara from the right by-line to the near post, clearance by Ndiaye Papa Waigo.", RealTime = _startTime, Time = _startTime.ToShortTimeString() });
            events.Add(new Event { Id = 2, Text = "Quincy Owusu-Abeyie fires in a goal from deep inside the penalty box to the bottom right corner of the goal. Southampton 0-1 Portsmouth", RealTime = _startTime, Time = _startTime.ToShortTimeString() });
            events.Add(new Event { Id = 3, Text = "Dean Hammond takes a shot. Save made by David James.", RealTime = _startTime, Time = _startTime.ToShortTimeString() });
            events.Add(new Event { Id = 4, Text = "The ball is crossed by Nadir Belhadj.", RealTime = _startTime.AddSeconds(10), Time = _startTime.AddMinutes(3).ToShortTimeString() });
            events.Add(new Event { Id = 5, Text = "Unfair challenge on Richard Lambert by Hermann Hreidarsson results in a free kick. Dan Harding takes the direct free kick.", RealTime = _startTime.AddSeconds(20), Time = _startTime.AddMinutes(6).ToShortTimeString() });
            events.Add(new Event { Id = 6, Text = "Richard Lambert scores a headed goal from close in. Southampton 1-1 Portsmouth.", RealTime = _startTime.AddSeconds(30), Time = _startTime.AddMinutes(9).ToShortTimeString() });
            events.Add(new Event { Id = 7, Text = "Ndiaye Papa Waigo delivers the ball, save by David James.", RealTime = _startTime.AddSeconds(40), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 8, Text = "Frederic Piquionne comes on in place of John Utaka.", RealTime = _startTime.AddSeconds(50), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 9, Text = "Southampton make a substitution, with Lee Barnard coming on for Ndiaye Papa Waigo.", RealTime = _startTime.AddSeconds(52), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 10, Text = "Aruna Dindane is ruled offside. Indirect free kick taken by Kelvin Davis.", RealTime = _startTime.AddSeconds(60), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 11, Text = "Michail Antonio has an effort at goal from outside the penalty box which goes wide right of the target.", RealTime = _startTime.AddSeconds(62), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 12, Text = "Richard Lambert takes a shot. Blocked by Hermann Hreidarsson.", RealTime = _startTime.AddSeconds(64), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 13, Text = "Aruna Dindane grabs a goal from close in to the bottom left corner of the goal. Southampton 1-2 Portsmouth.", RealTime = _startTime.AddSeconds(65), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 14, Text = "Inswinging corner taken from the left by-line by Richard Lambert, Effort on goal by Dean Hammond from deep inside the penalty area misses to the right of the target. ", RealTime = _startTime.AddSeconds(70), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 15, Text = "Free kick awarded for a foul by Dean Hammond on Frederic Piquionne. Direct free kick taken by Jamie O'Hara. ", RealTime = _startTime.AddSeconds(72), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 16, Text = "Morgan Schneiderlin fouled by Hassan Yebda, the ref awards a free kick. ", RealTime = _startTime.AddSeconds(73), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 17, Text = "Wayne Thomas concedes a free kick for a foul on Quincy Owusu-Abeyie. Nadir Belhadj takes the direct free kick.", RealTime = _startTime.AddSeconds(75), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 18, Text = "The assistant referee flags for offside against Lee Barnard. David James restarts play with the free kick.", RealTime = _startTime.AddSeconds(80), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 19, Text = "Chris Perry fouled by Frederic Piquionne, the ref awards a free kick. Free kick taken by Kelvin Davis. ", RealTime = _startTime.AddSeconds(90), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 20, Text = "Header from deep inside the area by Michail Antonio goes over the bar. ", RealTime = _startTime.AddSeconds(91), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 21, Text = "Nadir Belhadj fires in a goal from close in to the bottom left corner of the goal. Southampton 1-3 Portsmouth. ", RealTime = _startTime.AddSeconds(92), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 22, Text = "Chris Perry goes off and Lee Holmes comes on. ", RealTime = _startTime.AddSeconds(92), Time = _startTime.AddMinutes(95).ToShortTimeString() });
            events.Add(new Event { Id = 23, Text = "Richard Lambert takes the inswinging corner, Hermann Hreidarsson makes a clearance.", RealTime = _startTime.AddSeconds(100), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 24, Text = "Jamie O'Hara finds the back of the net with a goal from inside the area to the bottom left corner of the goal. Southampton 1-4 Portsmouth.", RealTime = _startTime.AddSeconds(104), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 25, Text = "Corner crossed in by Jamie Hara. ", RealTime = _startTime.AddSeconds(105), Time = _startTime.AddMinutes(14).ToShortTimeString() });
            events.Add(new Event { Id = 26, Text = "The ball is crossed by Michail Antonio, clearance by Marc Wilson.", RealTime = _startTime.AddSeconds(107), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 27, Text = "Free kick awarded for an unfair challenge on Lee Barnard by Hermann Hreidarsson. Direct free kick taken by Adam Lallana.", RealTime = _startTime.AddSeconds(110), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 28, Text = "Lee Holmes sends in a cross, clearance by Nadir Belhadj. ", RealTime = _startTime.AddSeconds(115), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 29, Text = "Richard Hughes on for Hermann Hreidarsson.", RealTime = _startTime.AddSeconds(120), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 30, Text = "Adam Lallana takes a shot. Save by David James.", RealTime = _startTime.AddSeconds(125), Time = _startTime.AddMinutes(12).ToShortTimeString() });
            events.Add(new Event { Id = 31, Text = "The final whistle is blown by the referee.", RealTime = _startTime.AddSeconds(130), Time = _startTime.AddMinutes(12).ToShortTimeString() });

            return events;
        }
    }
}
