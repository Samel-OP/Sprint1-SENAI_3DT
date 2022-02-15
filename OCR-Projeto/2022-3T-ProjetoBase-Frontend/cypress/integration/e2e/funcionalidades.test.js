describe('Descricao', () => {
    beforeEach(() => {
        cy.visit('http://localhost:3000/')
    })

    it('Deve logar e inserir a imagem carregando a OCR no input de texto', () => {
        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()
        
        cy.get('.inputlogin').first().type('paulo@email.com')
        cy.get('.inputlogin').last().type('Teste12345')
        cy.get('.btnlogin').click()

        cy.get('.input[type=file]'),first().selesctFile('src/assets/tests/equipamento.jpeg');

        cy.wait(3000)
        cy.get('#codigoPatrimonio').should('have.value', '1202529')
    })

    it('Deve excluir o equipamento'), ()=> {
        cy.get()
    }
})