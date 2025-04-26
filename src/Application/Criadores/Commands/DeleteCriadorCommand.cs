using Application.Global.ViewModels;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Criadores.Commands;

public sealed record DeleteCriadorCommand(int Id) : ICommand<DeleteViewModel>;

