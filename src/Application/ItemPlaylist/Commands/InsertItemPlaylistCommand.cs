using Application.Interfaces;
using Application.ItemPlaylist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ItemPlaylist.Commands;

public sealed record InsertItemPlaylistCommand(
    int PlaylistId,
    int ConteudoId
) : ICommand<InsertItemPlayListViewModel>;

