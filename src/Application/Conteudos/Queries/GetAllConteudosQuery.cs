using Application.Conteudos.ViewModels;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Conteudos.Queries;

public sealed record GetAllConteudosQuery() : IQuery<IEnumerable<ConteudoViewModel>>;

