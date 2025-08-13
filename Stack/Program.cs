// Stack
// 데이터를 쌓아올리는 자료 구조

// 규칙 : LIFO(Last-In-First-Out)

// 원리 : 마지막에 들어간 데이터가 가장 먼저 나옴
// C#에서 구현 : System.Collections.Generic과 Stack<T> 사용

// ex) 브라우저 뒤로가기(가장 최근 브라우저로 돌아가기)
//     실행 취소(가장 최근 작업 취소)

// 주요 메서드
// Push() : 데이터 삽입
// Pop() : 데이터 꺼내기(삭제)
// Peek() : 최상단 데이터 확인(삭제는 아님)
// Count() : 스택에 있는 데이터 개수
// Clear() : 스택 비우기(전부 삭제)

// 장점 : 구현이 쉽고 Push/Pop 속도가 빠름
// 단점 : 중간에 위치한 데이터로의 접근이 느림

// 내부 동작 방식
// 배열 기반 vs 연결 리스트 기반
// 배열 기반은 처음 크기가 정해지면 그 이상 넣을 수 없다.
// 연결 리스트 기반 스택은 노드를 계속해서 추가하면 크기 제한 없이 사용 가능하다.

// 주의사항
// 1. 스택 오버플로
// 크기가 정해진 스택이 꽉 찼는데 더 넣으려고 할 때 발생
// 보통 배열 기반 스택에서 자주 발생
// 2. 스택 언더플로
// 비어 있는 스택을 pop()할 때 발생


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> st = new Stack<int>();
        // Push 3개
        st.Push(10);
        st.Push(20);
        st.Push(30);
        
        Console.WriteLine($"After Push: Count = {st.Count}"); // 3

        // Peek (제거 없음)
        Console.WriteLine($"Peek = {st.Peek()}");             // 30
        Console.WriteLine($"After Peek: Count = {st.Count}"); // 3

        // Pop 두 번
        Console.WriteLine($"Pop = {st.Pop()}");               // 30
        Console.WriteLine($"Pop = {st.Pop()}");               // 20
        Console.WriteLine($"After Pop x2: Count = {st.Count}");// 1

        st.Pop();
        Console.WriteLine($"After Clear: Count = {st.Count}");// 0

        // Clear
        st.Clear();
        Console.WriteLine($"After Clear: Count = {st.Count}");// 0
    }
}


//  큐, 우선수위 큐, 양방향 큐



