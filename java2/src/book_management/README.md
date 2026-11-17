# Book Management

Java Swing과 JDBC를 사용하는 도서관리 수업 실습이다. 현재는 프로그램 시작 시 Oracle에서 도서를 조회하여 검색 탭의 표에 표시하는 단계까지 구현했다.

## 구성

- `domain/Book.java`: 도서번호, 도서명, 저자명, 출판사명, 가격, 재고, 분류명을 담는다.
- `repository/JDBCConnector.java`: 기존 수업용 Oracle 연결 설정을 사용한다.
- `repository/BookRepository.java`: 도서명·출판사명·저자 중 조건을 선택하여 `LIKE ?`로 조회하고 `ArrayList<Book>`을 반환한다.
- `view/BookSearchPan.java`: 검색 도구와 읽기 전용 `JTable`을 구성한다. `initView()`로 표를 만들고 `putSearchResult()`로 값을 채운다.
- `view/center/`: 창의 중앙 좌표와 기본 창 설정을 담당한다.
- `controller/BookController.java`: 시작 시 조회한 목록을 패널에 전달하고 도서 검색 탭을 표시한다.

## 실행과 확인 범위

IntelliJ에서 `java2`를 열고 JDK와 Oracle JDBC 드라이버를 설정한 뒤 `BookController.main()`을 실행한다. Oracle과 기존 수업 테이블 `BOOK`, `CATEGORY`, `PUBLISH`, 연결 설정이 필요하다. 비밀번호는 이 설명에 기록하지 않는다.

Java 21에서 컴파일했고, 이 PC의 IntelliJ에서 실제 Oracle 도서 3건과 7개 열이 표시되는 것을 확인했다. 빈 검색어로 시작하므로 초기 화면에는 조인 조건을 만족하는 전체 도서가 나온다.

현재 검색 버튼 이벤트는 연결하지 않았다. 입력값을 바꾼 뒤 버튼으로 재검색하는 동작과 추가·수정·삭제 화면은 다음 수업 단계이다.

실행 근거와 완료 보고서는 [기록 폴더](../../docs/records/)에 보관한다. 컴파일 결과인 `out/`와 새 `.class` 파일은 업로드 대상에서 제외한다.
