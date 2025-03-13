﻿using BlazorBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Infrastructure.Repository;

public class ArticleRepository(ApplicationDbContext context) : IArticleRepository
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Article> CreateArticleAsync(Article article)
    {
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();
        return article;
    }

    public async Task<bool> DeleteArticleAsync(int id)
    {
        var articleToDelete = await _context.Articles.FindAsync(id);
        if (articleToDelete is null)
        {
            return false;
        }
        _context.Articles.Remove(articleToDelete);
        _context.SaveChanges();
        return true;
    }

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task<Article?> GetArticleByIdAsync(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        return article;
    }

    public async Task<Article?> UpdateArticleAsync(Article article)
    {
        var articleToUpdate = await GetArticleByIdAsync(article.Id);

        if (articleToUpdate is null)
        {
            return null;
        }

        articleToUpdate.Title = article.Title;
        articleToUpdate.Content = article.Content;
        articleToUpdate.DatePublished = article.DatePublished;
        articleToUpdate.IsPublished = article.IsPublished;
        articleToUpdate.DateUpdated = DateTime.Now;
        articleToUpdate.UserId = articleToUpdate.UserId;
        await _context.SaveChangesAsync();

        return articleToUpdate;
    }
}