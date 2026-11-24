# Book Management

Java Swing과 JDBC를 사용하는 도서관리 수업 실습이다. Oracle 도서를 표로 조회하고 화면에서 추가·수정·삭제할 수 있다.

## 구성

- `domain/Book.java`: 도서번호, 도서명, 저자명, 출판사명, 가격, 재고, 분류명을 담는다.
- `repository/JDBCConnector.java`: 기존 수업용 Oracle 연결 설정을 사용한다.
- `repository/BookRepository.java`: 도서명·출판사명·저자 중 조건을 선택하여 `LIKE ?`로 조회하고 `ArrayList<Book>`을 반환한다.
- `view/BookSearchPan.java`: 검색 도구와 읽기 전용 `JTable`을 구성한다. `initView()`로 표를 만들고 `putSearchResult()`로 값을 채운다.
- `view/BookInsertPan.java`: DB에 등록된 출판사와 카테고리를 골라 책을 추가한다. 수정 화면에서도 같은 입력 폼을 사용한다.
- `view/BookUpdatePan.java`: 목록 표에서 도서를 고르면 아래 입력칸에 값이 채워진다. 도서번호는 고정하고 다른 정보를 수정할 수 있다. 삭제하려면 해당 행을 우클릭하고 **도서 삭제**를 고른 다음 확인한다.
- `view/center/`: 창의 중앙 좌표와 기본 창 설정을 담당한다.
- `controller/BookController.java`: 시작 시 조회한 목록을 패널에 전달하고 도서 검색 탭을 표시한다.

## 실행과 확인 범위

IntelliJ에서 `java2`를 열고 JDK와 Oracle JDBC 드라이버를 설정한 뒤 `BookController.main()`을 실행한다. Oracle과 기존 수업 테이블 `BOOK`, `CATEGORY`, `PUBLISH`, 연결 설정이 필요하다. 비밀번호는 이 설명에 기록하지 않는다.

Java 21에서 컴파일했고, 이 PC의 IntelliJ에서 실제 Oracle 도서 3건과 7개 열이 표시되는 것을 확인했다. 빈 검색어로 시작하므로 초기 화면에는 조인 조건을 만족하는 전체 도서가 나온다.

도서 검색이나 수정 및 삭제 탭으로 전환할 때 Oracle에서 다시 조회한다. 수정 저장 또는 삭제 직후에는 현재 표도 갱신한다. 검색 탭의 조회에는 입력된 검색어와 검색 기준이 적용된다. 화면의 도서번호는 Oracle의 `BOOK.ISBN`에 연결되며, 현재 Java 도메인은 정수형이라 실습용 짧은 번호를 사용한다.

실행 근거와 완료 보고서는 [기록 폴더](../../docs/records/)에 보관한다. 컴파일 결과인 `out/`와 새 `.class` 파일은 업로드 대상에서 제외한다.
