import { useEffect, useState } from "react";
import "./Portfolio.css";

const profileUrl = "https://github.com/kangseok0427";
const pages = [
    { id: "home", label: "홈" },
    { id: "about", label: "소개" },
    { id: "projects", label: "프로젝트" },
];
const projects = [
    {
        name: "AI VTuber 가온",
        category: "AI",
        description: "치지직 채팅을 받아 답변과 음성을 생성하고 캐릭터의 표정을 제어하는 AI 버튜버 시스템입니다.",
        technologies: ["LangGraph", "RVC", "VTube Studio"],
        link: "https://github.com/kangseok0427/gaon-project",
    },
    {
        name: "Satellite Infection",
        category: "게임",
        description: "직접 기획하고 개발한 게임 프로젝트입니다. 저장소에서 구현 내용을 확인할 수 있습니다.",
        technologies: ["C#", "Python"],
        link: "https://github.com/kangseok0427/SatelliteInfection",
    },
    {
        name: "AI VTuber Light",
        category: "AI",
        description: "AI 버튜버의 대화 처리에 필요한 기능을 중심으로 구성한 경량 실습 프로젝트입니다.",
        technologies: ["LangChain", "Python", "Ollama"],
    },
];

function activePage() {
    const hash = window.location.hash.slice(1);
    return pages.find((page) => page.id === hash) ?? pages[0];
}

function HomePage() {
    return (
        <section className="portfolio-shell portfolio-home">
            <p className="portfolio-kicker">AI 개발 포트폴리오</p>
            <h1>강석현<span>.</span></h1>
            <p className="portfolio-home-intro">대화하는 AI와 게임을 개발합니다.</p>
            <p className="portfolio-copy">실시간 음성·캐릭터 제어부터 데이터와 화면을 연결하는 프로그램까지, 만들고 실행한 작업을 모았습니다.</p>
            <div className="portfolio-actions">
                <a className="portfolio-primary" href="#projects">프로젝트 보기 <span aria-hidden="true">↗</span></a>
                <a className="portfolio-secondary" href="#about">개발자 소개</a>
            </div>
        </section>
    );
}

function AboutPage() {
    return (
        <section className="portfolio-shell portfolio-subpage">
            <h1>개발자 소개</h1>
            <p className="portfolio-lead">인공지능소프트웨어학과에서 AI와 소프트웨어 개발을 공부하고 있습니다.</p>
            <div className="portfolio-about">
                <article>
                    <h2>AI 캐릭터</h2>
                    <p>Python으로 대화 흐름을 만들고 음성, 채팅, 캐릭터 화면을 하나의 시스템으로 연결합니다.</p>
                    <p className="portfolio-tech">Python · LangGraph · RVC</p>
                </article>
                <article>
                    <h2>게임 개발</h2>
                    <p>C#과 Unity를 활용해 플레이어의 조작을 구현하고, 실제 플레이로 기능을 확인합니다.</p>
                    <p className="portfolio-tech">C# · Unity</p>
                </article>
            </div>
        </section>
    );
}

function ProjectCard({ project }) {
    return (
        <li className="portfolio-project">
            <p className="portfolio-kicker">{project.category}</p>
            <h2>{project.name}</h2>
            <p>{project.description}</p>
            <p className="portfolio-tech">{project.technologies.join(" · ")}</p>
            {project.link && <a className="portfolio-project-link" href={project.link} target="_blank" rel="noreferrer">코드 보기 ↗</a>}
        </li>
    );
}

function ProjectsPage() {
    const [filter, setFilter] = useState("전체");
    const visible = filter === "전체" ? projects : projects.filter((project) => project.category === filter);

    return (
        <section className="portfolio-shell portfolio-subpage">
            <h1>프로젝트</h1>
            <div className="portfolio-filters" role="group" aria-label="프로젝트 분류">
                {["전체", "AI", "게임"].map((category) => (
                    <button type="button" key={category} aria-pressed={filter === category} onClick={() => setFilter(category)}>
                        {category}
                    </button>
                ))}
            </div>
            <ul className="portfolio-projects" aria-label={filter + " 프로젝트"} aria-live="polite">
                {visible.map((project) => <ProjectCard key={project.name} project={project} />)}
            </ul>
        </section>
    );
}

const pageComponents = { home: HomePage, about: AboutPage, projects: ProjectsPage };

export default function Portfolio() {
    const [page, setPage] = useState(activePage);

    useEffect(() => {
        function onNavigation() {
            setPage(activePage());
        }
        window.addEventListener("hashchange", onNavigation);
        return () => window.removeEventListener("hashchange", onNavigation);
    }, []);

    useEffect(() => {
        document.title = page.label + " | 강석현 포트폴리오";
        window.scrollTo(0, 0);
    }, [page]);

    const Page = pageComponents[page.id];
    return (
        <div className="portfolio">
            <header className="portfolio-header">
                <div className="portfolio-shell portfolio-header-inner">
                    <a className="portfolio-brand" href="#home" aria-label="강석현 포트폴리오 홈">KSH<span>.</span></a>
                    <nav aria-label="주 메뉴">
                        {pages.map((item) => (
                            <a key={item.id} href={"#" + item.id} aria-current={page.id === item.id ? "page" : undefined}>{item.label}</a>
                        ))}
                    </nav>
                </div>
            </header>
            <main><Page /></main>
            <footer className="portfolio-footer">
                <div className="portfolio-shell portfolio-footer-inner">
                    <p>강석현 · 인공지능소프트웨어학과</p>
                    <a href={profileUrl} target="_blank" rel="noreferrer">GitHub ↗</a>
                </div>
            </footer>
        </div>
    );
}
