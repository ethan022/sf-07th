// 1. 연결리스트의 정의

// 정의 : 연결리스트는 데이터를 노드(Node)라는 단위로 저장하고,
// 각 노드가 다음 노드의 주소를 가지고 있는 자료구조
// 노드(Node): 데이터 1개 + 다음/이전 노드로 가는 주소(Next,Prev)를 가진 메모리 단위
// 간단한 예시 : 노드(Node) 3개(A, B, C)를 만들어서 서로 이어 붙이고 출력

using System;
using System.Collections.Generic;
class DoublyNode
{
    public string Data;              // 노드가 담는 데이터
    public DoublyNode Next;          // 다음 노드를 가리키는 주소(오른쪽)
    public DoublyNode Prev;          // 이전 노드를 가리키는 주소(왼쪽)
    public DoublyNode(string data)
    { // 생성자: 노드 생성 시 데이터 전달
        Data = data;                 // 전달받은 데이터를 필드에 저장
    }
}





// 2. 연결리스트의 종류

// 1) 단일 연결 리스트(Singly Linked List)
// 구조 : Data -> Next
// 특징 : 한 방향으로만 탐색

// 2) 이중 연결 리스트 (Doubly Linked List)
// 구조 : Prev ← Data → Next
// 특징 : 앞/뒤 양방향 탐색 가능
// 'System.Collections.Genric' 네임스페이스에 포함된 'LinkedList<T>' 클래스를 이용
// 각 노드는 'LinkedListNode<T>' 객체로 표현됨.

// 3) 원형 연결 리스트 (Circular Linked List)
// 구조 : 마지막 노드 → 첫 노드 연결
// 특징 : 순환 구조, 무한 루프 순회 가능


// 3. 연결 리스트의 용도

// 1) 삽입 / 삭제가 잦은 상황

// 2) 동적 크기 필요할 때

// 3) 양방향 탐색 필요 → 이중 연결리스트

// 4) 순환 구조 필요 → 원형 연결리스트

// 5) 다른 자료구조의 기반 -> 스택, 큐, 그래프 인접 리스트 등 다양한 자료구조의 기반으로 사용됨





// 4. 연결 리스트의 장단점

// <장점>
// 1) 동적 크기 조절 가능 → 메모리 효율적 사용
// 2) 삽입/삭제가 빠름 → 포인터(주소)만 수정하면 됨
// 3) 다양한 변형 가능 → 단일, 이중, 원형 등 구조 확장 가능

// <단점>
// 1) 임의 접근 불가 → 특정 위치 탐색 시 맨 앞(First)부터 화살표(Next)를 n번 따라가야 함
// 2) 추가 메모리 필요 → Next/Prev 포인터(주소) 저장해야 함
// 3) 캐시 효율 낮음 → 배열보다 실제 실행 속도 느릴 수 있음



// 5. 연결리스트 vs 리스트 vs 배열 핵심비교
// 배열(Array) → 고정 크기, 빠른 접근 필요할 때 유리
// 리스트(List<T>) → C#에서 가장 많이 쓰임, 크기 자동 관리 + 빠른 접근
// 연결리스트(LinkedList<T>) → 삽입/삭제가 많거나 순환 구조가 필요한 경우 적합

// 시간 복잡도
// O(1), 0(n) O(n**2)

// Dictionary, HashSet

// 트리, 그래프, 힙

namespace _0818_연결리스트_발표자료_1차수정
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 노드 3개 만들기
            DoublyNode A = new DoublyNode("A"); // "A" 노드 생성
            DoublyNode B = new DoublyNode("B"); // "B" 노드 생성
            DoublyNode C = new DoublyNode("C"); // "C" 노드 생성
            // 앞뒤로 연결 (A <-> B <-> C)
            A.Next = B;                  // A의 다음을 B로 연결
            B.Prev = A;                  // B의 이전을 A로 연결
            B.Next = C;                  // B의 다음을 C로 연결
            C.Prev = B;                  // C의 이전을 B로 연결
            // :작은_파란색_다이아몬드: 앞에서부터 출력

            Console.WriteLine("앞에서부터 출력:"); // 구분용 출력
            DoublyNode cur = A;          // 현재 노드를 A(헤드)로 시작
            while (cur != null)          // null이면 끝에 도달한 것
            {
                Console.Write(cur.Data + " <-> "); // 현재 노드의 데이터 출력
                cur = cur.Next;          // 다음 노드로 이동
            }
            Console.WriteLine("null");   // 마지막 표시
            // :작은_파란색_다이아몬드: 뒤에서부터 출력


            Console.WriteLine("뒤에서부터 출력:"); // 구분용 출력(줄바꿈 포함)
            cur = C;                      // 현재 노드를 C(테일)로 시작
            while (cur != null)           // null이면 시작 이전까지 간 것
            {
                Console.Write(cur.Data + " <-> "); // 현재 노드의 데이터 출력
                cur = cur.Prev;           // 이전 노드로 이동
            }
            Console.WriteLine("null");    // 시작 지점 이전 표시





            // 6. 연결리스트 주요메서도 사용 예시
            LinkedList<string> list = new LinkedList<string>();
            // 추가
            list.AddLast("A");          // A
            list.AddLast("B");          // A -> B
            list.AddFirst("HEAD");      // HEAD -> A -> B
            // 탐색
            var nodeA = list.Find("A"); // A 노드 찾기
            list.AddAfter(nodeA, "C");  // A 뒤에 C 추가  >> HEAD -> A -> C -> B
            // 출력
            foreach (var item in list)
                Console.Write(item + " -> ");
            Console.WriteLine("null");  // HEAD -> A -> C -> B -> null
            // 삭제
            list.Remove("A");           // A 삭제        HEAD -> C -> B
            list.RemoveFirst();         // HEAD 삭제             C -> B
            list.RemoveLast();          // 마지막(B) 삭제        C
            // Count
            Console.WriteLine("남은 노드 수: " + list.Count); // 1
        }
    }
}
